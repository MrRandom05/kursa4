using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Praktika4Kurs
{
    public static class Navigator
    {
        private static object prevPage = null;
        public static AppContext db;
        public static Frame NavFrame { get; set; }
        public static void Push(Page next)
        {
            try
            {
                prevPage = NavFrame.Content;
                NavFrame.Navigate(next);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void Pop()
        {
            try
            {
                if (prevPage != null)
                {
                    var prev = prevPage;
                    prevPage = NavFrame.Content;
                    NavFrame.Navigate(prev);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
