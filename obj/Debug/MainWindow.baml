   M S B A M L   `   `   `  ����H  DPayCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PayCalculatorPayCalculator  5   	       PayCalculator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PayCalculator     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5	      � .+�5
   
   �� $��Pay Calculator��6   $��Center=�6)   $	��Top=�6F   $��0,5,0,0q�6^   $��20(�6o   $
��Bold"�6}   �� 5   
   $��Select Level��6   $
��Left=�6'   $	��Top=�6B   $��
103,63,0,0q�6Z   �� 5   
   -   5         ��Name$ 
levelCombo��5      $
��Left=�6'   $	��Top=�6B   $��50��6Z   $��
175,63,0,0q�6e   �� 5   
   $��	Workplace��6   $
��Left=�6$   $	��Top=�6?   $��
288,63,0,0q�6W   �� 5   
   -   5        $ 	workCombo��5      $
��Left=�6&   $	��Top=�6A   $	��120��6Y   $��
354,63,0,0q�6e   �� 5   
   $��# ID (e.g. 123)��6   $
��Left=�6*   $	��Top=�6E   $��
539,63,0,0q�6]   �� 5   
   -   5         ��Name$ 	idTextBox��5      $
��Left=�6%   $��23��6@    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $��Center=�6x   $��61��6�   $��
622,63,0,0q�6�    �� 	MaxLength$ 6��6�   �� 5   
   $��
Shift Date��6   $
��Left=�6%   $	��Top=�6@   $��113,279,0,0q�6X   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ shiftDatePicker��5      $
��Left=�6.   $	��Top=�6I   $��175,279,0,0q�6a   $��85��6v   �� 5   
   $��
Work Hours��6   $
��Left=�6%   $	��Top=�6@   $��103,308,0,0q�6X   �� 5   
   -   5        $ workHourCombo��5      $
��Left=�6*   $	��Top=�6E   $��85��6]   $��175,308,0,0q�6h   �� 5   
   $��Start (e.g. 21:30)��6   $
��Left=�6-   $	��Top=�6H   $��290,279,0,0q�6`   �� 5   
   -   5        $ startTimeText��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $	��Top=�6d   $��Center=�6|   $��54��6�   $��386,279,0,0q�6�   $ 5��6�   �� 5   
   $��End (e.g. 07:00)��6   $
��Left=�6+   $	��Top=�6F   $��295,308,0,0q�6^   �� 5   
   -   5        $ endTimeText��5      $
��Left=�6'   $��23��6B   $
 Wrap=�6N   $	��Top=�6b   $��Center=�6z   $��54��6�   $��386,308,0,0q�6�   $ 5��6�   �� 5   
   -   5         ��Name$ 
breakCheck��5      $��
Meal Break��6'   $
��Left=�6<   $	��Top=�6W   $��483,285,0,0q�6o   �� 5   
   -	   5        $ uniformCheck��5      $��Uniform��6)   $
��Left=�6;   $	��Top=�6V   $��483,314,0,0q�6n   �� 5   
   -
   5        $ laundryCheck��5      $��Laundry All.��6)   $
��Left=�6@   $	��Top=�6[   $��603,285,0,0q�6s   �� 5   
   -   5        	 ��Name$	 	addButton��5      $	��Add��6$   $
��Left=�62   $	��Top=�6M   $��80��6e   $��603,311,0,0q�6p   6�   �� 5   
   -   5        $	 resetButton��5      $��Reset��6&   $
��Left=�66   $	��Top=�6Q   $��95��6i   $��20��6t   $��103,360,0,0q�6�   6�   �� 5   
   -   5        $	 
exitButton��5      $
��Exit��6%   $��Center=�64   $	��Top=�6Q   $��95��6i   $��20��6t   $��	0,360,0,0q�6�   6�   �� 5   
   -   5        $	 printButton��5      $��Print��6&   $
��Left=�66   $	��Top=�6Q   $��95��6i   $��20��6t   $��588,360,0,0q�6�   6�   �� 5    
   -   5        
 ��Name$
 listBox��5       $��Center=�6#   $	��180��6@   $	��Top=�6M   $	��580��6e   $��0,94,0,0q�6q   $��Courier New)�6�   $
��Bold"�6�   5!      5"      