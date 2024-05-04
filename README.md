this was my final project submitted to CS50-2022

This project, called Time Tracker, is designed to help you understand how you spend your time on your computer. It does this by keeping track of the active windows that you use and storing that information in a dictionary. Time Tracker has two executables: "Time_Tracker.exe" and "Display_stats.exe

I used C#, .NET framework, and the Visual Studio Integrated Development Environment (IDE).to Develop and Debug the program and i used CsvHelper to perform operations like loading the data from the file into the dictionary and updating the csv according to the dictionary

The "Time_Tracker.exe" executable runs in the background to track the active window that you're currently using. It does this every 10 seconds and stores the information in the dictionary. Every 5 minutes, the dictionary is converted into a CSV file so that the data can be stored and can be used by "Display_stas.exe" to display the graph. To make the most of Time Tracker, you can add the "Time_Tracker.exe" file to your startup programs. This will ensure that Time Tracker starts tracking your activity automatically whenever you turn on your computer.

"The "Display_stats.exe" executable allows you to view a graph of your time spent on different windows. The data is displayed in the form of a bar graph, with each bar representing the amount of time you've spent on a particular window. This can give you insights into how you're spending your time and help you identify areas where you might be able to improve your productivity. By analyzing the graph, you can see which windows you're using the most

The program.cs file is the entry point of the "Time_Tracker" program and is responsible for managing the program's execution. It contains the main function that is run when the program is launched, it is responsible for managing two timers. One timer is used to continuously update the loaded dictionary with new data, while the other timer is responsible for converting the updated dictionary into a CSV file at regular intervals.The dictionary is updated every 10 seconds, and the CSV file is created from the updated dictionary every 5 minutes.
