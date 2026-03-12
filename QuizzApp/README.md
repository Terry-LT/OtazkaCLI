# Quiz CMD App

This is my **personal command-line quiz application** that I use to prepare for tests at university.

## Purpose

I built this tool to make studying more interactive. Instead of just reading notes, I can **practice questions in a quiz format directly in the terminal**.

The app loads questions from a **CSV file** and lets me practice them repeatedly.

## My Study Workflow

My workflow for creating quizzes looks like this:

1. **Generate questions with AI**
   I ask AI to generate **multiple-choice questions** based on specific topics I need to study.

2. **Organize questions in Google Docs**
   I place all generated questions into a **Google Document** so they are easy to review and edit.

3. **Convert Google Doc to Google Spreadsheet**
   I use another script that converts the Google Document into a **Google Spreadsheet**.

   (P.S link to project will be later)

4. **Export to CSV**
   I download the spreadsheet as a **CSV file**.

5. **Practice using this app**
   I load the CSV file into this quiz application and practice answering the questions.

## Features

- Command-line interface (simple and fast)
- Randomized questions
- Randomized answer order
- Multiple-choice format
- CSV-based question database
- Useful for quick exam preparation

## Disclaimer

The original version of this project was written in **Python**.
Later, I decided to rewrite the application in **C#** in order to improve my skills in the C# programming language and gain more experience with building command-line applications in the .NET ecosystem.

The core idea and workflow of the project remained the same, but the implementation was redesigned in C# as a personal learning exercise.

## TODO

* Add more unit tests to improve reliability and maintainability of the application.
