   M S B A M L   `   `   `  ����H  DThe Song Mind, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:The_Song_Mind.PagesThe_Song_Mind.Pages  5      %    The_Song_Mind.Pages.MainDevPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:The_Song_Mind.Pages     5        N� Title$  MainDevPage��5	       � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  'd�       '�� T    '� �    '� �    '�� �    �� 5   
   " d�6.   .�5      ��  � ��
 �����6+   �� 5       � ��$ 5q�60   �� 5       � ��
 �   �6,   �� 5       � ��$ 50(�6)   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 10q�6(   5      �� 5   
   " ��6(   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 5q�60   �� 5       � ��
 �   �6,   �� 5       � ��$ 50(�6)   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ Center=�6;   �� 5       � ��$ 10q�6(   5       �� 5!   
   " �6)   .�5"      ��  � ��
 �����6%   �� 5#       � ��$ 10��60   �� 5$       � ��
 �   �6'   �� 5%       �@�Cursor$
 Hand��6'   �� 5&       �@��StrokeLineJoin$ Round=�6/   5'      �� 5(   
   " �6*   .�5)      ��  � ��$ 10��60   �� 5*       � ��
 �   �6'   �� 5+       �@�Cursor$
 Hand��6'   �� 5,       �@��StrokeLineJoin$ Round=�6/   �� 5-       �@��StrokeDashArray$ 4.5 3R�60   5.      �� 5/   
   " ��6+   .�50      ��  �@��IsFlicksEnabled . 67    51      P� 52       �@��Orientation$ 
Horizontal=�61   . �53      ��  � ��$ 60��6/   54      56      57      .��59      �  � ColumnDefinitions 5:   
   �� 5;      $��* �6   �� 5<      $��2* �6   .+�5@   
   �� $��0��6   
���   �$��5��63   �� 5A   
   $��1��6   
���   �$��5��63   � 5D   
   $��0��6   	 � RowDefinitions	 5E      �� 5F      $��* �6    �� 5G      $��2* �6    .+�5K      �� $��0��6   
���   �$��5��64   �� 5L      $��1��6   
���   �$��5��64   9� 5O      -   5        
 9�Name$
 FileDropDown��5O      $
��File��6F   $��0��6T   $��80(�6d   $
��Bold"�6r   $��10 0 0 0q�6�   .��5P      � $	��250��6   $
��Left=�6#   	 5Q      �� 5R      $��* �6(   �� 5S      $��* �6(   �� 5T      $��* �6(   .+�5W      �� -   5        $��0��5W      $
��Open��6*   $��50(�6L   $
��Left=�6Z   $
��20 0q�6|   �� 5X      -   5        $��1��5X      $
��Save��6*   $��50(�6L   $
��Left=�6Z   $
��20 0q�6|   �� 5Y      -   5        $��2��5Y      $��
Save as...��6*   $��50(�6T   $
��Left=�6b   $
��20 0q�6�   5Z      5[      9� 5^      -   5        $
 EditDropDown��5^      $
��Edit��6F   $��0��6T   $��80(�6d   $
��Bold"�6r   $��	180 0 0 0q�6�   .��5_      � $
��Left=�6   	 5`      �� 5a      $��* �6(   �� 5b      $��* �6(   �� 5c      $��* �6(   .+�5f      �� -   5        $��0��5f      $��Key...��6*   $��50(�6M   $
��Left=�6[   $
��20 0q�6}   �� 5g      -   5        $��1��5g      $��Time Signature...��6*   $��50(�6\   $
��Left=�6j   $
��20 0q�6�   5h      5i      �� 5l      -   5        $��0��5l      $
��Back��68   $��Center=�6G   $��450 20 20 240q�6k   
���   �$��5q�6�   $��50(�6�   $
��Bold"�6�   
������ $��0q�6�   � 5o      $��1��6   	 5p      �� 5q      $��* �6$   �� 5r      $��5* �6$   .+�5u      �� $��Lyrics��6   $��0��6*   $��80(�67   $
��Bold"�6E   $
��20 0q�6W   �� 5v      -	   5         ��Name$ Lyrics��5v   '   $��1��6   $��50(�6T    �� TextWrapping$
 Wrap=�6b    �� AcceptsReturn . $
��10 0q�6�   $��
20 0 20 20q�6�   
������ 6�   5w      5x      � 5{   
   $��1��6   	 5|      �� 5}      $��* �6    �� 5~      $��* �6    .+�5�      �� $��0��6   
���   �$��5��64   �� 5�      $��1��6   
���   �$��5��64   �� 5�      -
   5         ��Name$ Scroll��5�      $��Visible=�6+   $��Hidden=�6S   $��5q�6x   .��5�      � 	 5�      �� 5�      $��3* �6(   �� 5�      $��* �6(   .+�5�      �� $��0��6!   .+�5�      �� -   5         ��Name$ SongViewChords��5�   $   $��90(�6<   $��
60 60 60 0q�6J   �� 5�      -   5        $ SongViewLyrics��5�   $   $��70(�6<   $
��80 0q�6J   5�      5�      5�      �� 5�      -   5         ��Name$
 Play��5�      $��0��6p   $��77��6}   $��77��6�   $
��Left=�6�   $��20 350 0 76q�6�   $��0q�6�   �� 5�      -   5        $ Pause��5�      $��0��68   $��77��6E   $��77��6P   $
��Left=�6\   $��117 350 0 76q�6w   $��0q�6�   � 5�      $��1��6    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   	 5�      �� 5�      $��* �6$   �� 5�      $��* �6$   .+�5�      �� $��0��6   $��0��6)   
���   �$��5��6H   �� 5�      $��0��6   $��1��6)   
���   �$��5��6H   �� 5�      $��1��6   $��0��6)   
���   �$��5��6H   �� 5�      $��1��6   $��1��6)   
���   �$��5��6H   �� 5�      $��0��6   $��0��6*   .+�5�      �� $��Tempo��6    $	��100(�6-   $��Center=�6<   $
��Bold"�6Y   $��10q�6k   �� 5�      -   5        $ TempoReadout��5�       $��Center=�66   $��40(�6S   $
��Bold"�6a   �� 5�      -   5         ��Name$ TempoSlider��5�       � Minimum$ 40Q�6T    � Maximum$	 240Q�6a    �� TickFrequency$ 10Q�6o    �� IsSnapToTickEnabled . $
��50 0q�6�   5�      � 5�      $��1��6   $��0��6$   	 5�      �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      � $��0��6    5�      �� 5�      $��4* �6/   �� 5�      $��* �6/   .+�5�      �� $��	Metronome��6$   $��0��65   $��80(�6E   $
��Bold"�6S   $��Center=�6e   $��20 10 20 20q�6�   d� 5�      -   5         d�Name$ 	Metronome��5�   '   $	��Off��6v   $��Center=�6�   $��1��6�   $��10 15q�6�   $��8q�6�   5�      �� 5�      
���   �$��10��6/   $��1��6D   $��50 20 50 40q�6Q   � 5�      -   5         �Name$ 
BarCounter��5�      $��1��6/   $��50 20 50 40q�6<   5�      �� 5�      -   5        $ Melodies��5�      $��0��6B   $��1��6O   $��Melodies��6_   $	��120(�6r   �� 5�      -   5        $ Rhythms��5�      $��1��6@   $��1��6M   $��Rhythms��6]   $	��120(�6o   5�      5�      5�      5�      