using System;

namespace InterviewMatrix.Commands
{
    public interface ICommand<in T> where T : new()
    {
        void Run(T options);
    }
}
