using System;
using System.Windows.Forms;

public class Program
{
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using (var form = new DocumentGeneratorForm())
        {
            form.ShowDialog();
        }
    }
}

public class DocumentGeneratorForm : Form
{
    private TextBox fullNameTextBox;
    private TextBox addressTextBox;
    private TextBox phoneNumberTextBox;
    private Button generateButton;
    private TextBox documentTextBox;

    public DocumentGeneratorForm()
    {
        this.Text = "Document Generator";
        this.Size = new System.Drawing.Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Створюємо елементи форми
        this.fullNameTextBox = new TextBox();
        this.addressTextBox = new TextBox();
        this.phoneNumberTextBox = new TextBox();
        this.generateButton = new Button();
        this.documentTextBox = new TextBox();

        // Налаштовуємо елементи форми
        this.fullNameTextBox.Location = new System.Drawing.Point(20, 20);
        this.fullNameTextBox.Size = new System.Drawing.Size(200, 20);
        this.fullNameTextBox.Text = "Волик Максим";

        this.addressTextBox.Location = new System.Drawing.Point(20, 50);
        this.addressTextBox.Size = new System.Drawing.Size(200, 20);
        this.addressTextBox.Text = "Вулиця першотравнева 27 ,  м.Полтава";

        this.phoneNumberTextBox.Location = new System.Drawing.Point(20, 80);
        this.phoneNumberTextBox.Size = new System.Drawing.Size(200, 20);
        this.phoneNumberTextBox.Text = "+380975213259";

        this.generateButton.Location = new System.Drawing.Point(20, 110);
        this.generateButton.Size = new System.Drawing.Size(200, 30);
        this.generateButton.Text = "Згенерувати документ";
        this.generateButton.Click += GenerateButton_Click;

        this.documentTextBox.Location = new System.Drawing.Point(20, 150);
        this.documentTextBox.Size = new System.Drawing.Size(550, 200);
        this.documentTextBox.Multiline = true;
        this.documentTextBox.ScrollBars = ScrollBars.Vertical;

        // Додаємо елементи форми до контейнера
        this.Controls.Add(this.fullNameTextBox);
        this.Controls.Add(this.addressTextBox);
        this.Controls.Add(this.phoneNumberTextBox);
        this.Controls.Add(this.generateButton);
        this.Controls.Add(this.documentTextBox);
    }

    private void GenerateButton_Click(object sender, EventArgs e)
    {
        // Отримуємо значення, введені користувачем
        string fullName = this.fullNameTextBox.Text;
        string address = this.addressTextBox.Text;
        string phoneNumber = this.phoneNumberTextBox.Text;

        // Замінюємо значення полів у шаблоні
        string generatedDocument = ReplaceFieldsInTemplate("Шаблон 1", fullName, address, phoneNumber);

        // Виводимо згенерований документ у текстове поле
        this.documentTextBox.Text = generatedDocument;
    }

    private string ReplaceFieldsInTemplate(string template, string fullName, string address, string phoneNumber)
    {
        return template
            .Replace("[FullName]", fullName)
            .Replace("[Address]", address)
            .Replace("[PhoneNumber]", phoneNumber);
    }
}
