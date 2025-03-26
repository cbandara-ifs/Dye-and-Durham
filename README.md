# Dye & Durham Coding Assessment

## Overview

This is a console application that sorts a list of names by their last name, and then, by the given names. The application supports reading names from a file and saving the sorted list back to a new file.

## Features

- Read names from a text file.
- Sort names by last name.
- Sort by given names if the last name is the same.
- Output the sorted names to a new file.
- Display the sorted names in console.

## Prerequisites

- .NET 6.
- A text file containing names.

## Configuration

- Input File: The input file must contain names, one per line.
- Output File: The output file will be saved as sorted-names-list.txt by default.

## Example Input File (unsorted-names-list.txt)

```
Janet Parsons
Vaughn Lewis
Hunter Uriah Mathew Clarke
Marin Alvarez
```

## Example Output File (sorted-names-list.txt)

```
Marin Alvarez
Vaughn Lewis
Janet Parsons
Hunter Uriah Mathew Clarke
```

## Usage

### Running the Console App

1.  Open a terminal or command prompt.
2.  Navigate to the project folder where the application is built.
3.  Run the application by providing the input file path:

```
dotnet run ./unsorted-names-list.txt
```

## SOLID Principal Adherence

### SRP

- Validation, path creation, read from file, sorting, write to file and display in console have SRP methods

### OCP

- ` _fileProcessors.FirstOrDefault(p => p.SupportsExtension(extension))` making it extensible without modifying existing code

### LSP

- All `_fileProcessors` implement a common interface `(IFileProcessor)`, then replacing one with another does not break behavior

### ISP

- implement only methods relevant to them

### DIP

- All dependencies are injected via DI, making the code independent of specific implementations

## performance consideration

-   All I/O-bound operations are async

### Memory Usage

- Rather than loading all names to memory, process names lazily

```
using var reader = new StreamReader(filePath);
string? line;
while ((line = await reader.ReadLineAsync()) != null)
{
    yield return line;
}
```
