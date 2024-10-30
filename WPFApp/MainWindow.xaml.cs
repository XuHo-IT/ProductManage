using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public MainWindow()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
        }

        public void LoadCategoryList()
        {
            try
            {
                var list = categoryRepository.GetCategories();
                if (list != null && list.Any())
                {
                    cboCategory.ItemsSource = list;
                    cboCategory.DisplayMemberPath = "CategoryName";
                    cboCategory.SelectedValuePath = "CategoryID"; // Ensure this is correctly set
                    cboCategory.SelectedIndex = -1; // Clear any selected item
                }
                else
                {
                    MessageBox.Show("No categories available.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        public void LoadProductList()
        {
            var list = productRepository.GetProducts();
            dgData.ItemsSource = null;
            dgData.ItemsSource = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Product selectedProduuct)
            {
                txtProductID.Text = selectedProduuct.ProductId.ToString();
                txtProductName.Text = selectedProduuct.ProductName;
                txtUnitsInStock.Text = selectedProduuct.UnitsInStock.ToString();
                txtPrice.Text = selectedProduuct.Price.ToString();
                cboCategory.SelectedValue = selectedProduuct.CategoryID;
            }
            //DataGrid dataGrid = sender as DataGrid;
            //DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dgData.SelectedIndex);
            //DataGridCell column = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            //string id = ((TextBlock)column.Content).Text;
            //Product product = productRepository.GetProductById(Int32.Parse(id));
            //if(product != null)
            //{
            //    txtProductID.Text = product.ProductId.ToString();
            //    txtProductName.Text = product.ProductName;
            //    txtUnitsInStock.Text = product.UnitsInStock.ToString();
            //    txtPrice.Text = product.UnitPrice.ToString();
            //    cboCategory.SelectedValue = product.CategoryId;
            //}
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product()
                {
                    ProductName = txtProductName.Text,
                    UnitsInStock = short.Parse(txtUnitsInStock.Text),
                    Price = Decimal.Parse(txtPrice.Text),
                    CategoryID = Int32.Parse(cboCategory.SelectedValue.ToString()),
                };
                productRepository.SaveProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    // Get the existing product by its ID
                    Product existingProduct = productRepository.GetProductById(Int32.Parse(txtProductID.Text));
                    if (existingProduct != null)
                    {
                        // Update the fields of the existing product
                        existingProduct.ProductName = txtProductName.Text;
                        existingProduct.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                        existingProduct.Price = Decimal.Parse(txtPrice.Text);
                        existingProduct.CategoryID = Int32.Parse(cboCategory.SelectedValue.ToString());

                        // Call the repository method to update the product
                        productRepository.UpdateProduct(existingProduct);
                        MessageBox.Show("Product updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    Product existingProduct = productRepository.GetProductById(Int32.Parse(txtProductID.Text));
                    if (existingProduct != null)
                    {
                        productRepository.DeleteProduct(existingProduct);
                        MessageBox.Show("Product deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            Application.Current.Shutdown();
        }
    }
}