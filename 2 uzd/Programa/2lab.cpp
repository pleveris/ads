// ADS 2 lab.work, task num: 18, done by AA&PL (PRIF 19/3)

#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
using namespace std;

class Queue
{
private:
    vector<double> decNums;
    vector<string> binNums;
    int start, end;

public:
    Queue()
    {
        start = -1;
        end = -1;
    }

    bool isEmpty()
    {
        if (start == -1)
            return true;
        else
            return false;
    }

    void enQueue_num(double value)
    {
        if (start == -1)
            start = 0;
        end++;
        decNums.push_back(value);
        //        cout << value << " has been added to the queue";
    }

    void enQueue_bin(string value)
    {
        //        if(start == -1) start = 0;
        //        end++;
        binNums.push_back(value);
        //        cout << value << " has been added to the queue";
    }

    void deQueue()
    {
        string value;
        if (isEmpty())
        {
            cout << "Queue is empty!!" << endl;
        }
        else
        {
            value = binNums[start];
            if (start >= end)
            {
                start = -1;
                end = -1;
            }
            else
            {
                start++;
            }
            //            cout << value << " has been deleted from the queue";
            //            return(value);
        }
    }

    void outputQueueToScreen()
    {
        int i;
        if (isEmpty())
        {
            cout << endl
                 << "Queue is Empty, nothing to output!" << endl;
        }
        else
        {
            //            cout << endl << "start = " << start;
            cout << endl
                 << "Elements in the Queue: " << endl;
            for (i = start; i <= end; i++)
                cout << "Dec: " << decNums[i] << " -> Bin: " << binNums[i] << endl;
            //            cout << endl << "end = " << end << endl;
        }
    }

    void outputQueueToFile()
    {
        int i;
        string fln = "result.txt";
        ofstream out(fln);
        if (isEmpty())
        {
            out << endl
                << "Queue is Empty, nothing to output!" << endl;
        }
        else
        {
            //            cout << endl << "start = " << start;
            out << endl
                << "Elements in the Queue: " << endl;
            for (i = start; i <= end; i++)
                out << "Dec: " << decNums[i] << " -> Bin: " << binNums[i] << endl;
            out.close();
            cout << "Result written in: " << fln << endl;
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
            q.enQueue_num(n);
            q.enQueue_bin(decToBin(n, pl));
            cout << n << " has been successfully converted to a binary representation and put to the queue." << endl;

            cout << endl
                 << "Results: " << endl;
            q.outputQueueToScreen();
            cout << endl;
        }
        else if (choice == 2)
            q.outputQueueToFile();
        else if (choice == 3)
        {
            q.deQueue();
            q.outputQueueToScreen();
        }

        else
            break;
    }
    return 0;
}