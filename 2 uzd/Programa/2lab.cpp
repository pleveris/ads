// ADS 2 lab.work, task num: 18, done by AA&PL (PRIF 19/3)

#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
using namespace std;

struct ConvertedValue
{
    double initial;
    string converted;
};

class Queue
{
private:
    int size = 0;
    int capacity = 10;
    ConvertedValue *arr;
    int start = 0;
    int end = -1;

public:
    Queue()
    {
        arr = new ConvertedValue[capacity];
    }
    bool isEmpty()
    {
        if (size == 0)
            return true;
        else
            return false;
    }

    void enQueue(ConvertedValue value)
    {
        if (capacity == size)
        {
            cout << "Queue is full";
            return;
        }
        end++;
        arr[end] = value;
        size++;
    }
    ConvertedValue deQueue()
    {
        if (isEmpty())
        {
            cout << "Queue is empty!!" << endl;
            ConvertedValue empty;
            return empty;
        }
        ConvertedValue value;
        value = arr[start];
        start++;
        size--;
        return value;
    }

    void outputQueue(ostream &output)
    {
        int i;
        if (isEmpty())
        {
            output << endl
                   << "Queue is Empty, nothing to output!" << endl;
        }
        else
        {
            output << endl
                   << "Elements in the Queue: " << endl;
            for (i = start; i <= end; i++)
                output << "Dec: " << arr[i].initial << " -> Bin: " << arr[i].converted << endl;
        }
    }
};

string decToBin(double num, int places)
{
    string bin = "";
    int first = num;             // All number till the decimal separator
    double second = num - first; // All the number after the decimal separator
    while (first)
    {
        int p1 = first % 2;
        bin.push_back(p1 + '0'); // Forming result string
        first /= 2;
    }
    reverse(bin.begin(), bin.end()); // Should be seen from backside
    bin.push_back('.');
    while (places--)
    {
        second *= 2;
        int res = second;
        if (res == 1)
        {
            second -= res;
            bin.push_back(1 + '0');
        }
        else
            bin.push_back(0 + '0');
    }
    return bin;
}

int main()
{
    Queue q;
    int choice, pl;
    double n;
    cout << endl
         << endl;
    cout << "     Decimal fraction to binary converter     Menu";
    while (1)
    {
        cout << endl
             << endl;
        cout << "Possible choices: " << endl
             << endl
             << "1. Enter a decimal number and convert it to a binary representation (result will be shown in the screen console); " << endl
             << "2. Print all results into a textfile; " << endl
             << "3. Remove an existing element from the queue; " << endl
             << "Any other key to exit application." << endl;
        cin >> choice;
        if (choice == 1)
        {
            cout << "Enter a decimal fraction:     ";
            cin >> n;
            cout << endl
                 << "How many numbers would you like to see after the decimal separator?     ";
            cin >> pl;
            ConvertedValue conversion;
            conversion.initial = n;
            conversion.converted = decToBin(n, pl);
            q.enQueue(conversion);
            cout << n << " has been successfully converted to a binary representation and put to the queue." << endl;

            cout << endl
                 << "Results: " << endl;
            q.outputQueue(cout);
            cout << endl;
        }
        else if (choice == 2)
        {
            string fln = "result.txt";
            ofstream out(fln);
            q.outputQueue(out);
        }
        else if (choice == 3)
        {
            q.deQueue();
            q.outputQueue(cout);
        }

        else
            break;
    }
    return 0;
}