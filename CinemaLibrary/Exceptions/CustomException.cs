using System;

namespace CinemaLibrary.Exceptions
{
    /// <summary>
    /// Базовый класс для всех пользовательских исключений
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message){}

        public CustomException(string message, Exception innerException) : base(message, innerException){}

        public CustomException(){}
    }

    /// <summary>
    /// Исключение, возникающее при недостаточном числе работников киностудии
    /// </summary>
    public class NotEnoughPeopleException : CustomException
    {
        public NotEnoughPeopleException(): base("Слишком мало людей для съёмки фильма"){}
    }

    /// <summary>
    /// Исключение, выбрасываемое при возникновении проблем во время разбора строки
    /// </summary>
    public class StringFormatException : CustomException
    {
        public StringFormatException(string message, Exception innerException) :
            base($"Не удалось разобрать строку '{message}'", innerException){}

        public StringFormatException():base("Не удалось разобрать строку"){}

        public StringFormatException(string message) : base(message){}
    }

    /// <summary>
    /// Данное исключение возникает, когда зарплата сотрудника задана отрицательным числом
    /// </summary>
    public class NegativeValueException : CustomException
    {
        public NegativeValueException():base("Значение не может быть отрицательным"){}

        public NegativeValueException(string message) : base(message){}
    }

    /// <summary>
    /// Исключение, выбрасываемое при нарушении порядка вызова методов Work() и Hire() у класса Producer
    /// </summary>
    public class HiringOrderException : CustomException
    {
        public HiringOrderException(): base("Необходимо вызвать Work(film) перед наймом актёров"){}
    }
}