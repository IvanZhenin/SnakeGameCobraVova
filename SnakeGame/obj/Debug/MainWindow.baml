   M S B A M L   `   `   `  ����D  @SnakeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SnakeGame	SnakeGame  5   	       SnakeGame.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SnakeGame     5   	     � Title$U  OЗмейка играть по сети без регистрации и смс��5   	   $	��455��6=   $	��800��6M    � Icon 5	      �� 5
   
    �� 	UriSource$ /Resources/Logo.jpg?�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��200* �6   $	��400��6,   �� 5      $
��600* �6    � RowDefinitions 5   
   �� 5      $
��405* �6   �� 5      $��50 �6   .+�5   
   (� $��15q�6   $��0��6   $��0��6.   .��5      �� $��/Resources/Logo.jpg��6   5      (� 5   
   $��1��6   .��5      �� $��1q�6   
���   �$��0��6=   $	��400��6J   $	��400��6V   ._�5      A� -   5         A�Name$ 	gameBoard��5      $��0��61   $	��400��6>   $	��400��6J   
����ح�|�. 5      5      5       �� 5"   
   $��1��6   $��1��6"   .+�5#      �� $��Center=�6   $��Center=�62   $��5q�6M   ._�5$      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5%      �� -   5         ��Name$ 	textScore��5%       $��5q�63   $��Center=�6>   $��18(�6Y   �� 5&      -   5        $��Рестарт��5&      $��18(�6/   $��5q�6=   6H   �� 5'      -   5         ��Name$ buttonPause��5'      $��Пауза 1000-7��62   $��18(�6I   $��5q�6W   6b   5(      5)      5*      5+      5,      