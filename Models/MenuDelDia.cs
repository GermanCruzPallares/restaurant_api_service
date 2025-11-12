namespace Models;

public class MenuDelDia
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int PlatoPrincipalId { get; set; }
    public PlatoPrincipal? PlatoPrincipal { get; set; }
    public int BebidaId { get; set; }
    public Bebida? Bebida { get; set; }
    public int PostreId { get; set; }
    public Postre? Postre { get; set; }
    public double PrecioTotal { get; set; }
<<<<<<< HEAD
}
=======
}
>>>>>>> master
