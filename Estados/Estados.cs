namespace NameSpaceEstados;
class Estado
{
    protected Stack<Estado> estados;
    protected bool finalizar = false;
    public Estado(Stack<Estado> estados) //Constructor
    {
        this.estados = estados;
    }

    public bool consultarFinalizar()
    {
        return this.finalizar;
    }
    virtual public void Update()
    {

    }
}