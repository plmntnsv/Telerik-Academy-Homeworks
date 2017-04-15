using System;

public class SimpleMathExam : Exam
{
    public const int MaxProblemsSolved = 10;
    public const int MinProblemsSolved = 0;
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved)
            {
                this.problemsSolved = MinProblemsSolved;
            }
            else if (value > MaxProblemsSolved)
            {
                this.problemsSolved = MaxProblemsSolved;
            }
            else
            {
                this.problemsSolved = value;
            }

        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
