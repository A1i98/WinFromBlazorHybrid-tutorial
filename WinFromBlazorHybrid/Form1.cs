using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace WinFromBlazorHybrid
{
    public partial class Form1 : Form
    {
        readonly Data _data = new();
        public Form1()
        {
            InitializeComponent();
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            _data.Form = this;
            services.AddSingleton<Data>(_data);
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<Counter>("#app");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _data.Count++;
            label1.Text = _data.Count.ToString();
            _data.UpdateOnBlazor();
        }
    }
}