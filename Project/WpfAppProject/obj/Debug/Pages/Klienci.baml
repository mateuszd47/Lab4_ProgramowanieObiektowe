   M S B A M L   `   `   `  ����H  DWpfAppProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfAppProject.PagesWpfAppProject.Pages  5      !    WpfAppProject.Pages.Klienci   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WpfAppProject.Pages     5        N� Title$  Klienci��5	      .��5      � 
������  � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� 
�������$
��Bold"�5      $
��Imie��5      $��	10 20 0 0q�5      $	��Top=�5      $
��Left=�5      5      �� 5      -   5         ��Name$
 imie��5!      $
��Bold"�5      $��90��5      $��20��5      $��
130 20 0 0q�5      $	��Top=�5      $
��Left=�5       5!      �� 5#      
�������$
��Bold"�5%      $��Nazwisko��5&      $��	10,50,0,0q�5'      $	��Top=�5(      $
��Left=�5)      5*      �� 5+      -   5        $ nazwsiko��52      $
��Bold"�5,      $��90��5-      $��20��5.      $��
130,50,0,0q�5/      $	��Top=�50      $
��Left=�51      52      �� 55      
�������$
��Bold"�57      $��Telefon��58      $��	10,80,0,0q�59      $	��Top=�5:      $
��Left=�5;      5<      �� 5=      -   5        $ telefon��5D      $
��Bold"�5>      $��90��5?      $��20��5@      $��
130,80,0,0q�5A      $	��Top=�5B      $
��Left=�5C       �� 	MaxLength$ 9��5E      �� 5G      
�������$
��Bold"�5I      $��Adres Email��5J      $��
10,110,0,0q�5K      $	��Top=�5L      $
��Left=�5M      5N      �� 5O      -   5        $ adrese��5V      $
��Bold"�5P      $��90��5Q      $��20��5R      $��130,110,0,0q�5S      $	��Top=�5T      $
��Left=�5U      5V      �� 5X      
�������$
��Bold"�5Z      $��Kod-Pocztowy��5[      $��
10,140,0,0q�5\      $	��Top=�5]      $
��Left=�5^      5_      �� 5`      -   5        $ kodPoczatowy��5g      $
��Bold"�5a      $��90��5b      $��20��5c      $��130,140,0,0q�5d      $	��Top=�5e      $
��Left=�5f      5g      �� 5i      
�������$
��Bold"�5k      $��Adres��5l      $��
10,170,0,0q�5m      $	��Top=�5n      $
��Left=�5o      5p      �� 5q      -   5        $ adres��5x      $
��Bold"�5r      $��90��5s      $��20��5t      $��130,170,0,0q�5u      $	��Top=�5v      $
��Left=�5w      5x      �� 5z      
�������$
��Bold"�5|      $��Staly Klient��5}      $��
10,200,0,0q�5~      $	��Top=�5      $
��Left=�5�      5�      �� 5�      -   5        $ stalyKlient��5�      $
��Bold"�5�      $��90��5�      $��20��5�      $��130,200,0,0q�5�      $	��Top=�5�      $
��Left=�5�      $ 1��5�      �� 5�      
�������$
��Bold"�5�      $��
ID Klienta��5�      $��230,563,0,0q�5�      $	��Top=�5�      $
��Left=�5�       J� RenderTransformOrigin$ 7.558,15.37&�5�      5�      �� 5�      -   5        $ idKlient��5�      $
��Bold"�5�      $��90��5�      $��20��5�      $��300,566,0,0q�5�      $	��Top=�5�      $
��Left=�5�      5�      �� 5�      -	   5        $��Update��5�      
�������$��Bottom=�5�      $��Right=�5�      $��
0 0 240 60q�5�      ��5�      �� 5�       �� 
TargetType" ��6   .�5�      ��  �� Property � �� �� Value �#462AD867    �� Triggers 5�      P� 5�      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5�   "   ��  � �� �#28AEED6?   5�      5�      ��5�      �� 5�       �� 
TargetType" ��6&   .R�5�      �� $	��150��6!   $��40��5�   !    �� CornerRadius$ 5��5�   !   #��z��5�   !   ._�5�      �� $��Center=�6/   $��Center=�5�   7   5�      5�      5�      �� 5�      -
   5        $��Delete��5�      
�������$��Bottom=�5�      $��Right=�5�      $��	0 0 10 60q�5�      ��5�      �� 5�      " ��6   .�5�      ��  � �� �	#FFD8322A67    5�      P� 5�      	 �@J�IsMouseOver
 . . �5�   "   ��  � �� �#28AEED6?   5�      5�      ��5�      �� 5�      " ��6&   .R�5�      �� $	��150��6!   $��40��5�   !   $ 5��5�   !   #��z��5�   !   ._�5�      �� $��Center=�6/   $��Center=�5�   7   5�      5�      5�      �� 5�      -   5        $
��Send��5�      
�������$��Bottom=�5�      $��Right=�5�      $��	0 0 10 10q�5�      ��5�      �� 5�      " ��5�      .�5�      ��  � �� �	#FF2AD87C5�       5�      P� 5�      	 �@J�IsMouseOver
 . . �5�   "   ��  � �� �#28AEED5�   %   5�      5�      ��5�      �� 5�      " ��6&   .R�5�      �� $	��150��6!   $��40��5�   !   $ 5��5�   !   #��z��5�   !   ._�5�      �� $��Center=�5�   !   $��Center=�5�   !   5�      5�      5�      5      � 5  
   $��1��6   .+�5     �� $
��Auto=�6   $
��Auto=�6>   .��5     &   System.Windows.Controls.DataGrid  -   5          Name$ 
KlienciTab��5     5     5     5     5	     