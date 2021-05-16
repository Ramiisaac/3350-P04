# 3350-P04

Implement a console-based application. 

Your task is to implement a program that performs an operating system API call to open a text file named Data.txt, write 10,000 random numbers in the range [0..100] to the file, and close the file. 

Next, the program creates three thread tasks. 

Each thread task should:

1.    Perform an operating system API call to open the Data.txt file.
2.    Create a file named Thread_X_Data.txt, where X represents a letter A, B, or C, depending on which thread created the file.
3.    Copy the data from the Data.txt file to the Thread_X_Data.txt file.
4.    Close the Data.txt file.
5.    Close the Thread_X_Data.txt file.
6.    Compute the execution time.
7.    Output the execution time.

The main thread should wait for the thread tasks to complete. The main thread should also compute the execution time of all three thread tasks and output the result.
