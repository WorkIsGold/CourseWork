   M S B A M L   `   `   `  ����O  KShestakovCourse2Work, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ShestakovCourse2WorkShestakovCourse2Work  5   	   ;"clr-namespace:ShestakovCourse2WorkShestakovCourse2Work  5   	   ;"clr-namespace:ShestakovCourse2WorkShestakovCourse2Work  5   	   %    ShestakovCourse2Work.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ShestakovCourse2Work     5   	   1uc"clr-namespace:ShestakovCourse2Work     5   	   7Controls"clr-namespace:ShestakovCourse2Work     5   	   -   5          � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5         
stylePeaks    ShestakovCourse2Work.Peaks!   PreviewMouseLeftButtonDown   PreviewMouseLeftButtonUp   PreviewMouseMove"   PreviewMouseRightButtonDown  	InfoStyle �� 
TargetType �� Property  DeepAmethyst �� Value  EventStyleBackground��%1  &	        &	 �     7  &	 �    �� 5   
   .�5      ;� 6F   " btn_PreviewMouseLeftButtonDown;� 5   D     btn_PreviewMouseLeftButtonUp;� 5   <    btn_PreviewMouseMove;� 5   G   # btn_PreviewMouseRightButtonDown5      �� 5   
   " ��6"   .�5      ��  � ��8   6+   �� 5       � ��
 � ���6+   �� 5       � ��$
 Auto��6&   �� 5       � ��$
 Auto��6'   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   5      �� 5   
   .�5      -   5        5      5      .��5       � -   5        	 �Name$	 
Background��5       .+�5!   
   �� -   5        
 ��Name$
 canvasButton��5!        templateBackground#��[ 6'   #��[ 6V   �� 5"   
   -   5         ��Name$ canvas1��5"       J� 	AllowDrop .  J� RenderTransformOrigin$ 0.027,0.064&�64   $��0,0,0,0q�6X   $��Stretch=�6i   $��Stretch=�6�   .+�5#         ShestakovCourse2Work.Peaks  -   5          Name$ roundButton1��5#        templatePeaks#��[ 6-   #��[  5$       �� Left$	 400��61   
 �� Top$	 220��6C      Number$ 0��6T   �� 5%      
��� ���$��2q�6-   #��[ 6A    �� CornerRadius$ 7��6l   $��25��6}   $��26��6�   $ 10��6�   $ 10��6�   ._�5&      �� $��I��6   
��� ��� �� TextAlignment$ Center=�67   $��Center=�6N    � ToolTip 5'      _� 5(      #��[ 6"   
��� ���.��5)      �� .+�5*   "   �� 
��� ���#��[ 6>   $
 Left=�6i   ��Чтобы поставить новую вершину, нажмите правой кнопкой мыши в любом месте окна5,   #   �� 5-   "   
��� ���$��1q�6A   #��[ 6U   $ 1��6�   �� 5.   "   
��� ���#��[ 6>   $
 Left=�6i   ��Чтобы передвинуть вершину, нажмите по ней левой кнопкой мыши и перетащите в нужное место50   #   �� 51   "   #��[ 6)   
��� ���$��1q�6l   $ 1��6�   �� 52   "   
��� ���#��[ 6>   $
 Left=�6i   ��Чтобы соединить две вершины ребром, нажмите по одной из них правой кнопкой мыши�� 54   "   ��После чего на экране появится ребро и начнёт своим концом следовать за курсором�� 56   "   ��Перетащите курсор на вторую вершину и нажмите на неё правой кнопкой мыши, тогда ребро соединит эти вершины�� 58   "   ��Если Вы оба раза нажали на одну и ту же вершину, автоматически рядом появится новая вершина, уже соединённая с ребром5:   #   �� 5;   "   #��[ 6)   
��� ���$��1q�6l   $ 1��6�   �� 5<   "   
��� ���#��[ 6>   $
 Left=�6i   b`Для поиска базы независимых циклов графа нажмите Enter�� 5>   "   �� 5?   &   $P�JРёбра базы независимых циклов выделятся��6*    �� 5@   &   $"� зелёным цветом��6*     Emerald#��[ 6A   5A   #   �� 5B   "   #��[ 6)   
��� ���$��1q�6l   $ 2��6�   �� 5C   "   
��� ���#��[ 6>   $
 Left=�6i   KIЧтобы закрыть окно программы, нажмите Esc5E   #   5F      5G      5I      5J      �� 5K      -   5         ��Name$ 
textblock1��5K      $	 391��6,   $	 333��6>   #��[ 6O   �� 5L      -   5        $ 
textblock2��5L      $	 113��6,   $	 278��6>   $ 0.547,0.484&�6O   #��[ 6s   z�5M      V� 5N      .~�5O      ��  �� ScaleX$ 1Q�6)    �� ScaleY$ 1Q�64   �� 5P      �� 5Q       �� Angle$ 0Q�6*   T� 5R       T� X$ -5.815Q�6-    T� Y$ 1.668Q�68   5S      5U      �� 5V      -	   5        $ 
textblock3��5V      $	 107��6,   $	 248��6>   $ 0.5,0.5&�6O   #��[ 6o   z�5W      V� 5X      .~�5Y      �� �� 5Z      �� 5[      $ 0Q�6*   T� 5\      5]      5_        5`      -
   5        $ 
testclass1��5`      #��[ 6+   #��[  6U   $	 722��6y   $	 379��6�   $��Center=�6�   $	��Top=�6�   $ 1��6�   5a      5b      5c      