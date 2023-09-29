using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }



        // Абстрактні продукти
        interface IButton
        {
            void Render();
        }

        // Конкретні продукти - кнопки з різними стилями
        class WindowsButton : IButton
        {
            public void Render()
            {
                MessageBox.Show("Відображення кнопки Windows");
            }
        }

        class MacOSButton : IButton
        {
            public void Render()
            {
                MessageBox.Show("Відображення кнопки macOS");
            }
        }

        // Абстрактна фабрика
        interface IGUIFactory
        {
            IButton CreateButton();
        }

        // Конкретні фабрики - створюють продукти з відповідними стилями
        class WindowsFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new WindowsButton();
            }
        }

        class MacOSFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new MacOSButton();
            }
        }

        // Клієнтський код
        class Client
        {
            private IButton button;

            public Client(IGUIFactory factory)
            {
                button = factory.CreateButton();
            }

            public void Run()
            {
                button.Render();
            }
        }

        // Приклад використання
        class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                IGUIFactory factory;

                // Вибір фабрики в залежності від платформи
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    factory = new WindowsFactory();
                }
                else
                {
                    factory = new MacOSFactory();
                }

                Client client = new Client(factory);
                client.Run();
            }
        }

    }
}
