   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	       BookStore.MainMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   -   5          � Title$  	BookStore��5   	   $	��576��6   $
��1024��6+    � WindowStartupLocation$ CenterScreen=�6k   .��5	      �    SubBackground#���   6    � RowDefinitions 5
   
   �� 5      �� 5      $��45 �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��6* �6   .+�5   
   (� $��1��6    (� Stretch$
 Fill=�6   .��5      �   DefaultButtonBColor#���  6   .+�5      �� $��Right=�6A   $	��Top=�6]     	TimeColor#���  5      $��2��6A   ��5      ��  �� Path$ CurrentDateTime�5   A   5      5      �� 5   
   $��0��6   $��0��6"     DefaultBackground#���  62   .+�5      (� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	BookStore��6   $��0��60   $��1��6=   $��30(�6M    
 Header#��[ 6[   (� 5      $��50��6   .��5      �� -   5          Icon#���  5       $��3��6@   $��1��6M   $��10,15,10,10q�6]   $��Center=�6r   6�   5       5!      5"      �� 5#       J� Opacity$ 0Q�6   $��5��6$   �� 5$      -   5          DefaultButton#���  5$      $��50��6=   $��Таблицы��6^   �� 5%      $ 0Q�6   $��5��6$   �� 5&      -   5        #���  5&      $��50��6=   $��
Книги��6]   �� 5'      $ 0Q�6   $��5��6$   �� 5(      -   5        #���  5(      $��50��6=   $��
Выйти��6I   6Y   5)       � 5+   
   -   5          �Name$ 	MainFrame��5+      $��1��6#   $��2��63   	  � Source$"	 MainMenuPages/TablePage.xaml?�6D   
  � NavigationUIVisibility$
 Hidden=�6j   5,      5-      