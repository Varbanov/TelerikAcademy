using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(this.comments))
            {
                throw new ArgumentException("Comments are either null or empty");
            }

            this.comments = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentException("MaxGrade must be smaller than or equal to minGrade.");
            }

            this.maxGrade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("MinGrade must be positive.");
            }

            this.minGrade = value;
        }
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade must be positive.");
            }

            this.grade = value;
        }
    }
}
