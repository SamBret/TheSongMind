   M S B A M L   `   `   `  ����H  DThe Song Mind, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:The_Song_Mind.PagesThe_Song_Mind.Pages  5      %    The_Song_Mind.Pages.OptionsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:The_Song_Mind.Pages     5      -   5          N� Title$  OptionsPage��5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 5q�60   �� 5       � ��
 �   �6,   �� 5       � ��$ 40(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 80��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$
 Left=�6;   �� 5       � ��$
 15 0q�6(   5      5      .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5       $��* �6#   .+�5"      �� $��0��6   $��Options��6(   $
��Bold"�67   $	��130(�6I   $
��50 0q�6X   �� 5#      -   5        $��1��5#      $
��Back��68   $��Center=�6G   $��
700 0 50 0q�6k   5$      �� 5'   
   $��Volume��6   $
��Bold"�6"   $��80(�64   $��50 10q�6B   �� 5*   
   -   5         ��Name$ VolumeSlider��5*       � Maximum$ 10Q�6J    �� TickFrequency$ 1Q�6W   	 �� IsSnapToTickEnabled	 . $��5q�6�   
 � Cursor$

 Hand��6�   $��50 5 1000 5q�6�   �� 5-   
   $��	Shortcuts��6   $
��Bold"�6%   $��80(�67   $
��50 5q�6E   � 5/   
    50      �� 51      $��* �6#   �� 52      $��* �6#   .+�55      �� .+�57      �� -   5         ��Name$ CutShortcut��57      $
��50 5q�6.   6<   �� 58      -   5        $ CopyShortcut��58      $
��50 5q�6/   6=   �� 59      -   5        $ PasteShortcut��59      $
��50 5q�60   6>   �� 5:      -   5        $ DuplicateShortcut��5:      $
��50 5q�64   6B   �� 5;      -   5        $ UndoShortcut��5;      $
��50 5q�6/   6=   �� 5<      -	   5        $ RedoShortcut��5<      $
��50 5q�6/   6=   5=      �� 5>      -
   5        $��1��5>      $��Save Changes��6?   $��Center=�6V   $��Right=�6z   $��Bottom=�6�   $
��50 0q�6�   5?      5@      5A      