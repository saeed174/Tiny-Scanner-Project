# Tiny Language Scanner

A lexical analyzer (scanner) for the **TINY** programming language, implemented in C# (.NET 10.0). This project reads TINY source code and breaks it down into a stream of lexical tokens (keywords, identifiers, numbers, operators, and symbols).

---

## Features

- **Case-Insensitive Keyword Recognition**: Recognizes standard TINY keywords (`if`, `then`, `end`, `repeat`, `until`, `read`, `write`) regardless of casing (e.g., `IF`, `Then`, `repeat`).
- **Identifiers & Numbers**: Scans alphanumeric identifiers starting with a letter and integer literals.
- **Operators & Delimiters**: Supports assignment (`:=`), arithmetic operators (`+`, `-`, `*`, `/`), relational operators (`<`, `=`), brackets `(`, `)`, and statement terminators (`;`).
- **Whitespace & Error Handling**: Automatically skips whitespace/newlines while tracking line numbers, and flags unrecognized characters or malformed operators as `ERROR` tokens.
- **File Output**: Prints the scanned token list to the console and automatically saves the result to `output.txt`.

---

## Supported Token Types

| Category | Lexeme / Pattern | Token Type |
| :--- | :--- | :--- |
| **Keywords** | `if`, `then`, `end`, `repeat`, `until`, `read`, `write` *(case-insensitive)* | `IF`, `THEN`, `END`, `REPEAT`, `UNTIL`, `READ`, `WRITE` |
| **Identifiers** | `[a-zA-Z][a-zA-Z0-9]*` | `IDENTIFIER` |
| **Numbers** | `[0-9]+` | `NUMBER` |
| **Assignment** | `:=` | `ASSIGN` |
| **Relational Operators** | `<`, `=` | `LESSTHAN`, `EQUAL` |
| **Arithmetic Operators** | `+`, `-`, `*`, `/` | `PLUS`, `MINUS`, `MULT`, `DIV` |
| **Delimiters / Brackets** | `;`, `(`, `)` | `SEMICOLON`, `OPENBRACKET`, `CLOSEDBRACKET` |
| **End of File** | `EOF` | `ENDOFFILE` |
| **Invalid Input** | Any unrecognized character or lone `:` | `ERROR` |

---

## Project Structure

```text
TinyScanner/
└── TinyScanner/
    ├── TinyScanner.slnx               # Solution file
    └── TinyScanner/
        ├── Program.cs                 # Entry point, file I/O, and console UI
        ├── TinyScanner.cs             # Core lexical analyzer logic
        ├── Token.cs                   # Token class and TokenType enum definitions
        ├── TinyScanner.csproj         # .NET 10 project configuration
        └── tests/                     # Sample TINY test cases
            ├── test1_all_keywords.txt
            ├── test2_identifiers_numbers.txt
            ├── test3_operators.txt
            ├── test4_whitespace.txt
            ├── test5_keyword_identifiers.txt
            ├── test6_assign.txt
            ├── test7_empty.txt
            └── test8_invalid_chars.txt
```

---

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later.

### Building and Running

1. **Clone the repository:**
   ```bash
   git clone https://github.com/saeed174/Tiny-Scanner-Project.git
   cd Tiny-Scanner-Project
   ```

2. **Build the project:**
   ```bash
   dotnet build TinyScanner/TinyScanner/TinyScanner.csproj
   ```

3. **Run the scanner:**
   ```bash
   dotnet run --project TinyScanner/TinyScanner/TinyScanner.csproj
   ```

4. **Provide a test file when prompted:**
   You can enter the name of any test file inside the `tests` directory (e.g., `test1_all_keywords.txt`) or provide a path to a custom file.

---

## Example Usage

**Input (`test1_all_keywords.txt`):**
```tiny
if x < 10 then
    repeat
        x := x + 1
    until x = 10
    read y;
    write y
end
```

**Output:**
```text
Tokens found:
----------------------------
if, IF
x, IDENTIFIER
<, LESSTHAN
10, NUMBER
then, THEN
repeat, REPEAT
x, IDENTIFIER
:=, ASSIGN
x, IDENTIFIER
+, PLUS
1, NUMBER
until, UNTIL
x, IDENTIFIER
=, EQUAL
10, NUMBER
read, READ
y, IDENTIFIER
;, SEMICOLON
write, WRITE
y, IDENTIFIER
end, END
EOF, ENDOFFILE
----------------------------
```
