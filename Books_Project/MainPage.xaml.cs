using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Books_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BookList.ItemsSource = GetBookList();
        }

        public ObservableCollection<BookInfo> GetBookList()
        {
            const string GetBookQuery = @"SELECT [BookId] ,[BookTitle],[AuthorName], [ISBN], [NumberOfPage], [PublicationName], [PublishYear]
            FROM [dbo].[Books]";

            var BookInfos = new ObservableCollection<BookInfo>();
            try
            {

                using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BooksBD;Integrated Security = true"))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetBookQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var BookInfo = new BookInfo();
                                    BookInfo.BookId = reader.GetInt32(0);
                                    BookInfo.BookTitle = reader.GetString(1);
                                    BookInfo.AuthorName = reader.GetString(2);
                                    BookInfo.ISBN = reader.GetString(3);
                                    BookInfo.NumberOfPage = reader.GetInt32(4);
                                    BookInfo.PublicationName = reader.GetString(5);
                                    BookInfo.PublishYear = reader.GetInt32(6);

                                    BookInfos.Add(BookInfo);
                                }
                            }
                        }
                    }
                }
                return BookInfos;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BooksBD;Integrated Security = true");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Books]
           ([BookId],[BookTitle] ,[AuthorName], [ISBN], [NumberOfPage], [PublicationName], [PublishYear]) VALUES ( " + this.BookId.Text + ", '" + this.BookTitle.Text + "' ,'" + this.AuthorName.Text + "','" + this.ISBN.Text + "','" + this.NumberOfPage.Text + "','" + this.PublicationName.Text + "','" + this.PublishYear.Text + "')", con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            BookList.ItemsSource = GetBookList();

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BooksBD;Integrated Security = true");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            string updateString = " UPDATE[dbo].[Books]  SET [BookTitle] = '" + this.BookTitle.Text + "',[AuthorName] = '" + this.AuthorName.Text + "',[ISBN]= '" + this.ISBN.Text + "', [NumberOfPage] = '" + this.NumberOfPage.Text + "',[PublicationName] + '" + this.PublicationName.Text + "',[PublishYear] = '" + this.PublishYear.Text + "',  WHERE BookId = '" + this.BookId.Text + "'";

            SqlCommand cmd = new SqlCommand(updateString, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            BookList.ItemsSource = GetBookList();


        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BooksBD;Integrated Security = true");

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Books] WHERE BookId = ' " + this.BookId.Text + "'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            BookList.ItemsSource = GetBookList();
        }


    }



}
