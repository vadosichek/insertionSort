   M S B A M L   `   `   `  ���� E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CourseWork
CourseWork  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     CourseWork.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:CourseWork     9System&clr-namespace:System;assembly=mscorlib     $	��400��$	��800��  � 
ResizeMode$  NoResize=�.��� .+��� -    ��Name$ Backward��$��<��$
��Left=�$��52��$��	0,265,0,0q�$	��Top=�$	��238���� -   $ Forward��$��>��$
��Left=�$��52��$��238,265,0,0q�$	��Top=�$	��238���� -   $ Fastforward��$��>>��$
��Left=�$��52��$��238,317,0,0q�$	��Top=�$	��238���� -    ��Name$ SpeedSlider��$��	9,334,0,0q�$	��220��$
��Left=�$	��Top=� � Maximum$ 5Q� � Minimum$ 0.999Q��� -    ��Name$ MessageText��$
��Left=�$��26��$��	0,239,0,0q�$
��Wrap=�$	��Top=�$	��476��� -    �Name$ 	ArrayGrid��$
��Auto��$	��Top=�$��0,0,0,0q�$
��Left=��� -   $ TempText��$
��Left=�$��26��$��	0,213,0,0q�$
��Wrap=�$	��Top=�$	��476���� -   $ CodeText��$
��Left=�$��32��$��
476,32,0,0q�$
��Wrap=�$	��Top=�$	��316���� $�Псевдокод���� $�:���� -	   $ CodeTextBlock0��$
��Left=�$��50��$��
476,64,0,0q�$
��Wrap=�$	��Top=�$	��316���� $�for i = 2 to n do ���� �� $�    temp = A[i]���� �� $�    j = i - 1���� �� $+�%    while (j >= 1 and A[j-1] > x) do ���� �� $�        A[j] = A[j-1]���� �� $�        j = j - 1���� �� $�    end while���� �� $�    A[j] = x���� �� $�end for���� -
   $ CodeTextBlock1��$
��Left=�$��64��$��476,114,0,0q�$
��Wrap=�$	��Top=�$	��316���� $+�%    while (j > 0 and A[j] > temp) do ���� �� $�        A[j+1] = A[j]���� �� $�        j = j - 1���� �� $�    end while���� -   $ CodeTextBlock2��$
��Left=�$��32��$��476,178,0,0q�$
��Wrap=�$	��Top=�$	��316���� $�    A[j+1] = temp���� �� $�end for��o� $
��Left=�$��20��$	��Top=�$	��792��.@�m� $��Набор данных��.@�m� -    m�Name$ MenuItemCreate��$��Создать��m� -   $ MenuItemOpen��$��Открыть��m� -   $ MenuItemSave��$��Сохранить��