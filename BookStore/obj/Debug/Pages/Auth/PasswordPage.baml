   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   D @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore 5   	   '   !BookStore.Pages.Auth.PasswordPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   4sys&clr-namespace:System;assembly=mscorlib    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	     N� Title$  	BookStore��5	   	   $	��700��6   $	��500��6(   .��5
      �    DefaultBackground#���   6    � ColumnDefinitions 5   
   �� 5      �� 5      $��8* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.7* �6   �� 5      $
��0.7* �6   �� 5      $
��0.7* �6   �� 5      �� 5      .+�5   
   �� $��	BookStore��6   $��0��6$   $��1��61    
 Header#��[ 6A   �� 5   
   -   5         ��Name$ Login��5      $��1��6!   $��1��6.   $��70��6>   $	��300��6J   $��Bottom=�6V     DefaultTextBox#��[ 5      6:   �� 5   
   -   5         ��Name$ LoginPlaceholder��5      $��1��6*   $��1��67     Placeholder#��[ 6G   $��70��5      $	��300��6    $��
Логин��6,   $��Bottom=�6<   G� 5   
   -   5         G�Name$ OldPassword��5      $��2��6+   $��1��68   $��70��6H   $	��300��6T     DefaultPasswordBox#��[ 5      $��Center=�6B   �� 5    
   -   5        $ OldPasswordPlaceholder��5       $��2��60   $��1��6=   #��[ 6M   $��70��5!      $	��300��6    $��Center=�6,   $��Старый пароль��6G   G� 5#   
   -   5        $ Password��5#      $��3��6(   $��1��65   $��70��6E   $	��300��6Q   #��[ 5$      $	��Top=�6B   �� 5%   
   -   5        $ PasswordPlaceholder��5%      $��3��6-   $��1��6:   #��[ 6J   $��70��5&      $	��300��6    $	��Top=�6,   $��Новый пароль��6D   �� 5(   
   -   5         ��Name$ CancelButton��5(        DefaultButton#���  6'   $��3��6O   $��1��6\   $��24(�6l   $��Center=�5)      $��Bottom=�6.   $��45��6I   $	��240��6U   .��6|   Отмена6�   �� 5*   
   -   5        $ ChangePasswordButton��5*      #���  6/   $��4��6W   $��1��6d   $��Center=�5+      $��Center=�6.   $	��100��6I   $	��380��6V   .��6b   Сменить пароль6r   5,      5-      