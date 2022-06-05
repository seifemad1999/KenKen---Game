/******************************************************************************

                              Online C++ Compiler.
               Code, Compile, Run and Debug C++ program online.
Write your code in this editor and press "Run" button to compile and execute it.

*******************************************************************************/

#include <fcntl.h>
#include <locale.h>
#include <iomanip>
#include <iostream>
#include <locale>
#include <sstream>
#include <stdexcept>
#include <string>
#include <unordered_map>
#include <vector>
#include <map>
#include<fstream>
#include <chrono>
using namespace std;

typedef vector<vector<int>> Board;


class Position {
public:
    int x;
    int y;
    Position(int _x, int _y) : x(_x), y(_y) {}

    inline bool operator==(const Position& rhs) const {
        return this->x == rhs.x && this->y == rhs.y;
    }
    inline bool operator<(const Position& t2) {
        return (this->x < t2.x&& this->y < t2.y);
    }

    void set_x(int _x)
    {
        x = _x;
    }
    void set_y(int _y)
    {
        y = _y;
    }
};

namespace std {
    template <>
    struct hash<Position> {
        size_t operator()(const Position& p) const {
            return (p.x << 16) ^ p.y;
        }
    };
}  // namespace std

class Cage {
    vector<Position> positions;
    int value;
    wchar_t symbol;
    Position topLeft;

public:
    Cage(vector<Position> _positions, int _value, wchar_t _symbol)
        :positions(_positions),
        value(_value),
        symbol(_symbol),
        topLeft(-1, -1) {
        // Validate constraint definitions
        if (!(_symbol == '*' || _symbol == '/' || _symbol == '+' ||
            _symbol == '-' || _symbol == ' ')) {
            throw std::invalid_argument("Invalid operation symbol passed.");
        }
        if (_symbol == ' ' && this->positions.size() != 1) {
            throw std::invalid_argument(
                "Illegal cage size for that operation.");
        }
        if ((_symbol == '/' || _symbol == '-') && this->positions.size() != 2) {
            throw std::invalid_argument(
                "Illegal cage size for that operation.");
        }

        for (/*const*/ Position& p : this->positions) {
            if (topLeft.x == -1 || topLeft.y == -1) {
                topLeft.x = p.x;
                topLeft.y = p.y;
                continue;
            }
            if (p.x < topLeft.x || (p.x == topLeft.x && p.y < topLeft.y)) {
                topLeft.x = p.x;
                topLeft.y = p.y;
            }
        }
    }

    const Position& getRenderPosition() { return this->topLeft; }
    // Returns true if this cage contains this position.
    bool hasPosition(int x, int y)  {
        Position q = Position(x, y);
        for ( Position& p : this->positions) {
            if (p == q) return true;
        }
        return false;
    }

    // Returns whether or not a value fits this cage, given
    // the current board.
    bool fits(Board& board, int input) {
        vector<int> values;
        int emptySquares = 0;
        for ( Position& p : this->positions) {
            int v = board[p.x][p.y];
            if (!v)
                ++emptySquares;
            else
                values.push_back(v);
        }
        if (emptySquares > 1) {
            return true;
        }
        int acc;
        switch (this->symbol) {
        case ' ':
            return (input == this->value);
        case '*':
            acc = 1;
            for (int v : values) acc *= v;
            return (acc * input) == this->value;
        case '-':
            return ((input - values[0]) == this->value) ||
                ((values[0] - input) == this->value);
        case '+':
            acc = 0;
            for (int v : values) acc += v;
            return (acc + input) == this->value;
        case '/':
            return ((input / values[0]) == this->value &&
                (input % values[0] == 0)) ||
                ((values[0] / input) == this->value &&
                    (values[0] % input == 0));
        }

        return false;
    }

     vector<Position>& getPositions() {
        return this->positions;
    }
    friend wostream& operator<<(wostream&, Cage&);
};

wostream& operator<<(wostream& os, Cage & c) {
    return os << to_wstring(c.value) + c.symbol;
}


class Puzzle {
private:
    vector<Cage> cages;
    Board board;
    unordered_map<Position, Cage*> cageMap;

    bool isInitialized() {
        for (int i = 0; i < board.size(); ++i) {
            for (int j = 0; j < board[i].size(); j++) {
                if (this->board[i][j] < 0) return false;
            }
        }
        return true;
    }

public:
    Puzzle(vector<Cage> _cages, int _n)
        : cages(_cages), board(_n, vector<int>(_n, 0)) {
        // Validate puzzle definition
        for (int i = 0; i < cages.size(); ++i) {
            for ( Position& p : cages[i].getPositions()) {
                cageMap[p] = &cages[i];
            }
        }
        if (!this->isInitialized()) {
            throw invalid_argument("Insufficient cage coverage detected.");
        }
    }

    Board getBoard()  { return this->board; }

    void setBoard(Board b) { this->board = b; }

    bool columnHasValue(int x, int value)  {
        for (int i = 0; i < board.size(); ++i) {
            if (this->board[x][i] == value) {
                return true;
            }
        }
        return false;
    }

    bool rowHasValue(int y, int value)  {
        for (int i = 0; i < board.size(); ++i) {
            if (this->board[i][y] == value) {
                return true;
            }
        }
        return false;
    }

     Cage& findCage(int x, int y)  {
        return *(this->cageMap.at(Position(x, y)));
    }

    vector<int> possibleValues(int x, int y)  {
        vector<int> results;
        if (this->board[x][y]) {
            // Early exit; this square is already filled
            return results;
        }
        for (int i = 1; i <= this->board.size(); ++i) {
            if (rowHasValue(y, i) || columnHasValue(x, i)) {
                continue;
            }
            /*const*/ Cage& c = this->findCage(x, y);
            if (c.fits(this->board, i)) {
                results.push_back(i);
            }
        }
        return results;
    }

    bool isSolved()  {
        for (int i = 0; i < board.size(); ++i) {
            for (int j = 0; j < board[i].size(); j++) {
                if (this->board[i][j] <= 0) return false;
            }
        }
        return true;
    }

    void setValue(int x, int y, int value) { this->board[x][y] = value; }

    int getValue(int x, int y)  { return this->board[x][y]; }

    int size()  { return this->board.size(); }
};


bool forward_check(Puzzle &p,int value, int x, int y)
{
    // Cage
    Cage c = p.findCage(x, y);
    vector<Position> vect = c.getPositions();
    for(int i =0;i<vect.size(); i++)
    {
        if (p.getValue(vect[i].x, vect[i].y))
            continue;
        vector<int> temp = p.possibleValues(vect[i].x, vect[i].y);
            if (!temp.size())
                return false;
    }

    // rows 
    for (int i =0 ;i<p.size(); i++)
    {
        if (p.getValue(x, i))
            continue;
        vector<int> temp = p.possibleValues(x, i);
        if (!temp.size())
            return false;
    }

    //columns
    for (int i = 0;i< p.size(); i++)
    {
        if (p.getValue(i, y))
            continue;
        vector<int> temp = p.possibleValues(i, y);
        if (!temp.size())
            return false;
    }
    return true;
}

void solve_forward_check(Puzzle& p) {
    Board prev = p.getBoard();
    for (int i = 0; i < p.size(); ++i) {
        for (int j = 0; j < p.size(); ++j) {

            if (p.getValue(i, j)) {
                continue;
            }
            auto possible = p.possibleValues(i, j);
            if (!possible.size()) {
                p.setBoard(prev);
                return;
            }
            for (auto v : possible) {
                p.setValue(i, j, v);
                if (!forward_check(p, v, i, j))
                    continue;
                solve_forward_check(p);
                if (p.isSolved()) {
                    return;
                }
            }
        }
    }
    p.setBoard(prev);
}


void solve_backtracking(Puzzle& p) {
    Board prev = p.getBoard();
    for (int i = 0; i < p.size(); ++i) {
        for (int j = 0; j < p.size(); ++j) {

            if (p.getValue(i, j)) {
                continue;
            }
            auto possible = p.possibleValues(i, j);
            if (!possible.size()) {
                p.setBoard(prev);
                return;
            }
            for (auto v : possible) {
                p.setValue(i, j, v);
                solve_backtracking(p);
                if (p.isSolved()) {
                    return;
                }
            }
        }
    }
    p.setBoard(prev);
}

void solve_arc_consistency(Puzzle& p)
{
    
}

ifstream myfile_in("in.txt");
Puzzle reading_file(string &x)
{   
    string myText;
    vector<Position> temp_pos;
    vector<Cage> temp_cage;
    int value;
    char symbol;
    int i = 0;
    int puzzle_count=0;
    getline(myfile_in, x);
    while (getline(myfile_in, myText)) {
        if (myText.size() == 0)
            break;
        if(i==0)
        {
            i++;
            puzzle_count = stoi(myText);
            continue;
        }
        if (myText[0] =='+' || myText[0] == '-' || myText[0] == '*' || myText[0] == '/' || myText[0] == '#')
        {
            if(myText[0]=='#')
                symbol = ' ';
            else
                symbol = myText[0];

            Cage temp (temp_pos, value, symbol);
            temp_cage.push_back(temp);
            temp_pos.clear();
        }
        else if(myText[1] != ',')
        {
            value = stoi(myText);

        }
        else
        {
            int x = myText[0] - '0';
            int y = myText[2] - '0';
            Position temp(x, y);
            temp_pos.push_back(temp);
        }
    }
    Puzzle p (temp_cage, puzzle_count);
    //myfile_in.close();
    return p;
}

int main() {

 using namespace std;
 using namespace std::chrono;

    // reading the input puzzle
    string selected_algorithm;
    Puzzle p = reading_file(selected_algorithm);

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    
    // Solve the puzzle
    auto start = high_resolution_clock::now();
    if (selected_algorithm == "a1")
    {
        selected_algorithm = "solved with backtracking algorithm";
        solve_backtracking(p);
    }
    else if (selected_algorithm == "a2")
    {
        selected_algorithm = "solved with forward checking algorithm";
        solve_forward_check(p);
    }
        
    else if (selected_algorithm == "a3")
    {
        selected_algorithm = "solved with arc consistency algorithm";
        solve_arc_consistency(p);
    }
    else
        throw std::invalid_argument("Invalid algorithm that is not supported");

    //////////////////////////////////////////////////////////////////////////////////////////
    
    // calculate time execution
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<milliseconds>(stop - start);

    //////////////////////////////////////////////////////////////////////////////////////////
   
    // writing the output in file called out.txt    
    ofstream myfile_out;
	ofstream myfile_out_num;
    ofstream time_out;
    myfile_out.open("out.txt");
	myfile_out_num.open("out_num.txt");
    time_out.open("out_time.txt");
    myfile_out << selected_algorithm << "\n";
	myfile_out << "algorithm could solve the puzzle in time " << to_string(duration.count()) << " millisecond" << "\n";
    time_out << to_string(duration.count());
    for (int i = 0; i < p.size(); i++)
    {
        for (int j = 0; j < p.size(); j++)
        {
            myfile_out_num << to_string(p.getBoard()[i][j]) << "\n";
        }
    }
    myfile_out.close();
	myfile_out_num.close();
    time_out.close();
    ///////////////////////////////////////////////////////////////////////////////////////////
    return 0;
}
