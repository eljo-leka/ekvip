# ekvip

A command-line calculator application that implements the Command Pattern to perform operations on integer values.

## Overview

ekvip is a simple calculator that works with a single numeric value. It allows you to perform various operations on this value through commands like incrementing, decrementing, doubling, or adding a random value. The application also supports undoing previous operations.

## Features

- **Command Pattern Implementation**: Uses the Command design pattern to encapsulate and track operations
- **Command History**: Maintains a history of executed commands for undo functionality
- **Support for Multiple Command Types**:
  - Increment: Increases the current value by 1
  - Decrement: Decreases the current value by 1
  - Double: Multiplies the current value by 2
  - RandAdd: Adds a random value between 0 and 10 to the current value
  - Undo: Reverts the last executed command

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Building the Application

```bash
dotnet build
```

### Running the Application

```bash
dotnet run [initial_value]
```

Where `[initial_value]` is an optional parameter to set the starting value. If not provided, the application will prompt you to enter a value.

## Usage

1. Start the application with an optional initial value:
   ```bash
   dotnet run 5
   ```

2. The application will display available commands and prompt for input:
   ```
   Available commands: increment, decrement, double, randadd, undo. Insert 'exit' to exit.
   >
   ```

3. Enter a command at the prompt and press Enter:
   ```
   > increment
   Result: 6
   ```

4. Continue entering commands as desired:
   ```
   > double
   Result: 12
   ```

5. To undo the last command:
   ```
   > undo
   Result: 6
   ```

6. To exit the application:
   ```
   > exit
   Exiting application as requested by user.
   ```

## Command Details

### Increment Command
Increases the current value by 1.

### Decrement Command
Decreases the current value by 1.

### Double Command
Multiplies the current value by 2 and stores the previous value for undo functionality.

### Random Increment Command
Adds a random integer between 0 and 10 (inclusive) to the current value. The random value is stored to enable proper undoing of the command.

### Undo Command
Reverts the last executed command by calling the `Undo` method of that command. Multiple undo operations can be performed to step back through the command history.

## Architecture

The application follows the Command design pattern and is organized as follows:

- **Interfaces**: Contains the `ICommand` interface defining the contract for all commands
- **Commands**: Implementations of various commands
- **Enums**: Defines command types and helpers for enum handling
- **Processors**: The `CommandProcessor` class that manages command execution and tracking
- **Utils**: Helper methods for user interaction and application flow

### Class Structure

- **ICommand**: Interface for all command operations
- **CommandProcessor**: Manages command execution and history
- **EnumHelper**: Provides utilities for working with command enumerations
- **Utils**: Contains utilities for user interaction and application flow