   M S B A M L   `   `   `  ����?  ;TAXI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TAXITAXI  5   	   (    "TAXI.Modules.MainWindow.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:TAXI     5   	     � Title$
  TAXI��5   	   $	��450��6   $	��800��6#    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � $��0q�5   	    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� $��0��6      
ThirdColor#���   6!   � 5   
    � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      .+�5      F�   Logo#���  6     
FirstColor#���  61   $��5q�6U   $��Center=�6`   $��Center=�6{    �� Stretch$ Uniform=�6�   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Stretch=�6B   $��Center=�6^   .+�5       � $��Stretch=�6   $��Stretch=�63    5!      �� 5"      �� 5#      .+�5&      �� $��0��6    $��CREATE��6-   $��Center=�6;   $��0,5,0,0q�6V     FirstTextStyle#���  6g   �� 5(      $��1��6!   $ 
Horizontal=�6.   $��Stretch=�6G   $��0,0,0,0q�6c   .+�5*      	�  �� ContentStringFormat$
 RIDE��6&   $��Center=�6g     MenuItemsStyle#���  6�    	� 	GroupName$ MainMenu��6�   	 d� 	IsChecked$	 FalseY�6�   ��6A   �� *NavigateToAddRide+6�   	� 5+      $ CLIENT��6&   $��Center=�6k   #���  6�   $ MainMenu��6�   ��6C   �� *NavigateToAddClient+6�   	� 5,      $ DRIVER��6&   $��Center=�6k   #���  6�   $ MainMenu��6�   ��6C   �� *NavigateToAddDriver+6�   	� 5-      $	 CAR��6&   $��Center=�6e   #���  6�   $ MainMenu��6�   ��6@   �� *NavigateToAddCar+6�   	� 5.      $ 
TAXI CLASS��6&   $��Center=�6r   #���  6�   $ MainMenu��6�   ��6G   �� *NavigateToAddTaxiClass+6�   50      52      �� 54      $��1��6   $��30��6#   
 �� CornerRadius$
 1��6/   #��[ 6@   $��	10,0,10,0q�6i   � 56      $��Stretch=�6    57      �� 58      �� 59      .+�5<      �� $��0��6    $��SEARCH��6-   $��Center=�6;    �� TextAlignment$ Center=�6V   $��0,5,0,0q�6m   #���  6    J� IsHitTestVisible$ False��6�   �� 5>      $��1��6!   $ 
Horizontal=�6.   $��Stretch=�6G   $��0,0,0,0q�6c   .+�5@      	� $ CLIENT INFO��6&   $��Center=�6q   #���  6�   $ MainMenu��6�   ��6H   �� *NavigateToShowClient+6�   	� 5A      $ DRIVER AND CAR INFO��6&   $��Center=�6|   #���  6�   $ MainMenu��6�   ��6P   �� *NavigateToShowDriverCar+6�   	� 5B      $ 
RIDES LIST��6&   $��Center=�6o   #���  6�   $ MainMenu��6�   ��6G   �� *NavigateToShowRides+6�   5D      5F      5H      �� 5J      $��1��6   $	��Top=�6)   $��Right=�6A   $ 
Horizontal=�6]   $��3q�6v   .+�5L      �� 
������ $��0q�6O   $��15��6c     WindowButtons#���  6o   ��6   �� *
Minimize+��5M      F� 5N        Minimize#���  6   $ Uniform=�6A   #���  6S   $��1q�6w   5P      �� 5R      $��15��63   #���  6?   ��6   �� *Close+��5S      F� 5T       	 Close#���  6   $ Uniform=�6>   #���  6P   $��1q�6t   5V      5X      5Z      �� 5\   
   $��0��6   #���  6   $��
0, 0, 0, 1q�6I   �� 5^   
   -   5         ��Name$ ContentContainer��5^   &   $��1��6   
���  ��6@   5_      5`      