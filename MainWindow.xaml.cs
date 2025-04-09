using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab0101._10;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        InitializeDefaults();
    }
    
    
    
    private void SetBackgroundColor(string color)
    {
        switch (color)
        {
            case "Красный":
                DrawingCanvas.Background = Brushes.Red; 
                break;
            case "Зеленый":
                DrawingCanvas.Background = Brushes.Green; 
                break;
            case "Синий":
                DrawingCanvas.Background = Brushes.Blue; 
                break;
        }
    }
    
    private void ChangeColor(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.Tag is string colorName)
        {
            SetBackgroundColor(colorName.Split(' ')[0]); 
        }
    }
    
    
    
    private void ShowAbout(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Бондарев Максим с324", "Информация о разработчике");
    }
    
    private void CloseApp(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private void InitializeDefaults()
    {
        
        DrawingCanvas.DefaultDrawingAttributes.Color = Colors.Red;
        DrawingCanvas.DefaultDrawingAttributes.Width = 5;
        DrawingCanvas.DefaultDrawingAttributes.Height = 5;
    }
    
    
    private void ColorPicker_SelectionChanged(object sender, RoutedEventArgs e)
    {
        try
        {
            if (ColorPicker?.SelectedItem is ComboBoxItem selectedItem &&
                selectedItem.Tag is string colorName)
            {
                DrawingCanvas.DefaultDrawingAttributes.Color =
                    (Color)ColorConverter.ConvertFromString(colorName);
            }
        }
        catch
        {
            return;
        }
    }
    
    
    
    private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        try
        {
            double size = BrushSizeSlider.Value;
            DrawingCanvas.DefaultDrawingAttributes.Width = size;
            DrawingCanvas.DefaultDrawingAttributes.Height = size;
        }
        catch
        {
            return;
        }
    }

    private void Mode_Checked(object sender, RoutedEventArgs e)
    {
        try
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null) return;

            switch (radioButton.Content.ToString())
            {
                case "Рисование":
                    DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Редактирование":
                    DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Удаление":
                    DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
            }
        }
        catch
        {
            return;
        }
    }


}