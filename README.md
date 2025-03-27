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
## Design

The software is built following the principles of Clean Architecture, ensuring a clear separation of concerns. The Console Application serves as the UI Layer, while all business logic resides in the Application Layer. This separation allows the business logic to be encapsulated in a standalone class library, making it reusable if another UI layer is added in the future.

### Current Requirements & Design Decisions:

At present, the application focuses on reading from and writing to text files. However, the design is flexible enough to extend to other file formats in the future. To handle different file types dynamically, I applied the Strategy Design Pattern, which allows the algorithm to be selected at runtime based on the file extension. This approach enables future scalability for additional file types.

### Asynchronous I/O Operations:

To optimize resource usage, all I/O operations (such as file reading and writing) are implemented asynchronously. This ensures better utilization of the thread pool, especially when handling potentially blocking operations.

While sorting is a CPU-bound operation and doesn’t inherently require async processing, I chose to use async due to its integration with I/O-bound tasks, where the data fed into the sorting process is read asynchronously from the file.

### SOLID Principal Adherence

#### SRP

- Validation, path creation, read from file, sorting, write to file and display in console have SRP methods

#### OCP

- ` _fileProcessors.FirstOrDefault(p => p.SupportsExtension(extension))` making it extensible without modifying existing code

#### LSP

- All `_fileProcessors` implement a common interface `(IFileProcessor)`, then replacing one with another does not break behavior

#### ISP

- implement only methods relevant to them

#### DIP

- All dependencies are injected via DI, making the code independent of specific implementations

### performance consideration

-   All I/O-bound operations are async

#### Memory Usage

- Rather than loading all names to memory, process names lazily

```
using var reader = new StreamReader(filePath);
string? line;
while ((line = await reader.ReadLineAsync()) != null)
{
    yield return line;
}
```
