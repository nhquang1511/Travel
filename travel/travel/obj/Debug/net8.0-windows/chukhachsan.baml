   M S B A M L   `   `   `  ����A  =travel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:traveltravel  5   	       travel.chukhachsan   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:travel     5   	     � Title$  chukhachsan��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5         AutoGenerateColumns$ False��6M   "   VerticalScrollBarVisibility$
 Auto=�5      ��5   +   �� *	KhachSans+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
KhachSanID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *
KhachSanID+6\     5      $ TenKhachSan��6)   $ * 6^   	 6>   �� *TenKhachSan+6^     5      $ DiaChi��6)   $ * 6T   	 69   �� *DiaChi+6T     5      $ LoaiKhachSan��6%   $ * 6\   	 6;   �� *LoaiKhachSan+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Edit��6)   $
 Auto 67   
   CellTemplate
 5      �� 5      .R�5   "   �� $
��Edit��6)   5      5         5!      $ detail��6-   $
 Auto 6=   
 5"      �� 5#      .R�5$   "   �� $��detail��6)   5%      5'      5)      �� 5,   
   -   5        $��1��5,      $	��Add��6   $��Center=�6,   $
��0,10q�6I   6W   5-      5.      