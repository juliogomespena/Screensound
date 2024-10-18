using ScreenSound.Entidades;

namespace ScreenSound.Interfaces;

internal interface IAvaliavel
{
    string Nome { get; }
    Avaliacao Avaliacao { get; }
}
