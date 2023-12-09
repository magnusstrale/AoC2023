#!/bin/sh
# Steps to set up for Day X

DAY=Day$1
DAYTEST=Day$1test
mkdir $DAY
cd $DAY
dotnet new console -n $DAY
dotnet new xunit -n $DAYTEST
dotnet new sln
dotnet sln add $DAY/$DAY.csproj
dotnet sln add $DAYTEST/$DAYTEST.csproj
cd $DAYTEST
dotnet add reference ../$DAY/$DAY.csproj
cd ..
touch $DAY/input.txt
echo 'var lines = File.ReadAllLines("input.txt");' > $DAY/Program.cs
echo 'Console.WriteLine($"Part 1 {1}");' >> $DAY/Program.cs
echo 'Console.WriteLine($"Part 2 {2}");' >> $DAY/Program.cs
code .