   M S B A M L   `   `   `  ����  PresentationLayer#    PresentationLayer.pg9TakeQuiz   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  pg9TakeQuiz��5      .��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6    � RowDefinitions 5   
   �� 5      $��36 �6   �� 5       $��36 �6   �� 5!      $��36 �6   �� 5"      $��36 �6   �� 5#      $��36 �6   �� 5$      $��36 �6   �� 5%      $��36 �6   �� 5&      $��36 �6   �� 5'      $��36 �6   �� 5(      $��36 �6   �� 5)      $��36 �6   �� 5*      $��36 �6   .+�5.   
   �� $��1��6   $��1��6$   $��2��61   Your Progress:50      &   System.Windows.Controls.DataGrid  55   
   -   5        $��gameSummaryList��55         AutoGenerateColumns .  $��2��56      $��1��6   $��14��6*   $��8��6?   $ �� IsSynchronizedWithCurrentItem$
 TrueY�57         SelectionMode$ Single=�68      CanUserReorderColumns .     CanUserDeleteRows .     
IsReadOnly . 	   Columns	 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Level��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Level+  5;      $
 Category��6%   $	 500 67    6C   �� *
Category+  5<      $
 Status��6%   $	 300 65    6A   �� *UnlockedText+5>      �� 5B   
    �� Orientation$ 
Horizontal=�6   $��7��5C      $��10��6%   $��8��63   $��RightToLeft=�6G   $��0 5 0 0q�6c   .+�5D      �� -   5        $	��120��5D   )   $��
Go To Quiz��65   $��0 0 5 0q�6J   5E      5H      5J      