   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:BookStore.Pages.MainMenuPagesBookStore.Pages.MainMenuPages  5      -    'BookStore.Pages.MainMenuPages.TablePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:BookStore.Pages.MainMenuPages     5        N� Title$  	TablePage��5	      .��5      �    SubBackground#���   6    � RowDefinitions 5   
   �� 5      �� 5      $��8* �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5        $��TableSelector��5   :     ComboBox#���  6   $��
10 10 10 0q�6O   $��0��6c    �� Text$ Не выбрано��6s    �� 
IsEditable .  �� 
IsReadOnly . 5   ;   �� 5      -   5          DefaultButton#���  5      $"��Экспортировать��6=   $��
10,10,10,0q�6V   $��1��6j   6z   �� 5      -   5        #���  5      $ ��Импортировать��6=   $��2��6U   $��
10,10,10,0q�6e   6y   �� 5      -   5        #���  5      $/��)Создать/Редактировать��6=   $��3��6]   $��
10,10,10,0q�6m   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Table��5      $��1��6"     DataGrid#���  6/      
IsReadOnly .    CanUserReorderColumns .  	   SelectionMode$	 Single=�5    1   6H   � 5"   
   $��2��6    5#      �� 5$      �� 5%      �� 5&      �� 5'      .+�5)      �� -   5        #���  5)      $)��#Очистить выделение��6=   $��0��6Z   $��
10,0,10,10q�6j   6~   �� 5*      -   5        #���  5*      $+��%Удалить запись из БД��6=   $��1��6\   $��
10,0,10,10q�6l   6�   5+      5,      5-      