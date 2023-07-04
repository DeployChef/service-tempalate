namespace Template.Common.DTO;

/// <summary>
/// Ошибка
/// </summary>
public record ErrorDTO(string? Message, int Code)
{
    /// <summary>
    /// Код ошибки
    /// </summary>
    public int Code { get; } = Code;

    /// <summary>
    /// Текст ошибки
    /// </summary>
    public string? Message { get; } = Message;
}

