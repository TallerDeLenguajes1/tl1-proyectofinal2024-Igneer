namespace NameSpaceEstados;
class Estado
{
    protected Stack<Estado> estados;
    public Estado(Stack<Estado> estados) //Constructor
    {
        this.estados = estados;
    }
}