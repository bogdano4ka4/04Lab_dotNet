   M S B A M L   `   `   `  ����L  HPractice7UserList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Practice7UserList.Tools.Controls Practice7UserList.Tools.Controls  5      :    4Practice7UserList.Views.Authentication.AddPersonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ccontrols.clr-namespace:Practice7UserList.Tools.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   :   4Practice7UserList.Tools.Controls.LabelAndTextControl  $��0��6'   $��0��64   $��2��6D      Caption$
 Name��5   '   $��10q�66   $��2��6B      Text 5   X   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5   U     5   
   $��1��6'   $��0��64   $��2��6D   $ Surname��5   +   $��10q�6=   $��2��6I    5   X   �� *	Surname+$ PropertyChanged=�$ TwoWay=�5   \     5   
   $��2��6'   $��0��64   $��2��6D   $ Email��5   '   $��10q�67   $��2��6C    5   X   �� *Email+$ PropertyChanged=�$ TwoWay=�5   V   �� 5   
   $��3��6   $��0��6   $��Date of Birth:��6-   $��Center=�6F   $��Center=�6d   (  "System.Windows.Controls.DatePicker  5   
   $��3��6   $��1��6"   $��Stretch=�62   $��Center=�6P      FirstDayOfWeek$ Monday=�6k      IsTodayHighlighted .    SelectedDate 6�   �� *Birth+$ TwoWay=�$ PropertyChanged=��� 5    
   $��5��6   $��0��6   $��Stretch=�6.   $��Center=�6L   $��5q�6g   $��Create��6r   ��6�   �� *CreatePersonCommand+�� 5!   
   $��5��6   $��1��6   $��Stretch=�6.   $��Center=�6L   $��5q�6g   $
��Back��6r   ��6�   �� *BackCommand+5"   
   5#      