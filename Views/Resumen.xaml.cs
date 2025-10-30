
namespace LGAVIDIAEXA.Views;

public partial class Resumen : ContentPage
{
    private string v1;
    private string v2;
    private string v3;
    private string v4;
    private DateTime dateTime;
    private string v5;
    private string v6;
    private decimal inicial;
    private decimal pagoMensual;
    private decimal total;

    public Resumen()
	{
		InitializeComponent();
	}

    public Resumen(string v1, string v2, string v3, string v4, DateTime dateTime, string v5, string v6, decimal inicial, decimal pagoMensual, decimal total)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.dateTime = dateTime;
        this.v5 = v5;
        this.v6 = v6;
        this.inicial = inicial;
        this.pagoMensual = pagoMensual;
        this.total = total;
    }
}