   M S B A M L   `   `   `  ����  Practice7UserList*    $Practice7UserList.Views.UserListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��40 �6   6*   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� $��0��6   $��30��6!   $��Stretch=�6-   .@�5      �� $��Center=�6   $��Center=�62   $��Filter: ��6N   6c   �� 5      $��30��6d   $	��Top=�6p    �� SelectedIndex 6   �� *FilterIndex+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5      �� Name6"   �� 5      	Surname6%   �� 5      Email6#   �� 5      
Birthday6&   �� 5      
Is Adult6&   �� 5      
Sun Sign6&   �� 5      Chinese Sign6*   �� 5      Is Birthday6)   5      �� 5      $	��250��6   ��6"   �� *	Filtering+$ PropertyChanged=�6e   �� 5      ��6   �� *FilterCommand+$ PropertyChanged=�.��5      �� $��Filter��6   $
��Bold"�6*   6>   5      �� 5      $��30��6b   $	��Top=�6n    6   �� *	SortIndex+$ PropertyChanged=�.@�5      �� Name6"   �� 5       	Surname6%   �� 5!      Email6#   �� 5"      
Birthday6&   �� 5#      
Is Adult6&   �� 5$      
Sun Sign6&   �� 5%      Chinese Sign6*   �� 5&      Is Birthday6)   5'      �� 5(      ��6   �� *SortCommand+$ PropertyChanged=�.��5)      �� $
��Sort��6   $
��Bold"�6(   6<   5*      5,      &   System.Windows.Controls.DataGrid  5-   
   $��1��6   $��0��6    $��Center=�60      AutoGenerateColumns .  ��6N   �� *Users+ �� Mode$ OneWay=� �� SelectedItem 6y   �� *SelectedUser+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Name+$ TwoWay=�$ PropertyChanged=�6�     50      $ Surname��6%    66   �� *	Surname+6T     51      $ Email��6%    64   �� *Email+6P     52      $ Birthday��6%   	   
IsReadOnly	 .  6J   �� *BirthdayShort+6n     53      $ Is Adult��6%   	 .  6J   �� *	IsAdult+6h     54      $ Sun Sign��6%   	 .  6J   �� *	SunSign+6h     55      $ Chinese Sign��6%   	 .  6N   �� *ChineseSign+6p     56      $ Is Birthday��6%   	 .  6M   �� *
IsBirthday+6n   58      �� 59   
   $��2��6   $��30��6!   $��Stretch=�6-   $��0��6L   $��Bottom=�5:      .@�5;      �� ��6   �� *DeletePersonCommand+.��5<      �� $��Delete Person��6   $
��Bold"�61   6E   5=      �� 5>      $��Center=�6   ��62   �� *AddUserCommand+.��5?      �� $��
Add person��6   $
��Bold"�6.   6B   5@      �� 5B      $��Center=�6   ��62   �� *SaveCommand+.��5C      �� $��Save changes��6   $
��Bold"�60   6D   5D      �� 5E      $��Center=�6   ��62   �� *ShowAllCommand+.��5F      �� $��	Show All ��6   $
��Bold"�6-   6A   5G      5H      5J      5K      