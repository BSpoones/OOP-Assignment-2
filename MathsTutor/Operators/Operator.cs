namespace MathsTutor
{
    /*
     * Operator interface
     * 
     * Ensures Calculate is a method in all classes and subclasses
     */
    public interface IOperator
    {
        double Calculate(double val1, double val2);
    }

    /*
     * Operator abstract class
     * 
     * Abstract parent class for all other operators
     */
    public abstract class Operator: IOperator
    {
        public abstract double Calculate(double val1, double val2);
    }
}
