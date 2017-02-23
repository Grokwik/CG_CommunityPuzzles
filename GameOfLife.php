<?php

function GetNeighbourCount($line, $col)
{
    global $lines;
    global $width;
    global $height;

    $count = 0;
    $minline = ($line > 0) ? $line-1 : 0;
    $mincol = ($col > 0) ? $col-1 : 0;
    $maxline = ($line < $height-1) ? $line+1 : $height-1;
    $maxcol = ($col < $width-1) ? $col+1 : $width-1;
    for($i=$minline ; $i<$maxline+1 ; $i++)
    {
        for($j=$mincol ; $j<$maxcol+1 ; $j++)
        {
            if (!($i==$line && $j==$col))
                $count += $lines[$i][$j] == '1' ? 1 : 0;
        }
    }
    return $count;
}

// ===============================================
fscanf(STDIN, "%d %d", $width, $height);
$lines = array();
for ($i = 0; $i < $height; $i++)
{
    fscanf(STDIN, "%s", $line);
    $lines[] = $line;
//    error_log(var_export($line, true));
}

$ncount = array();
for ($line=0 ; $line<$height ; $line++)
{
    $ncount[] = array();
    for($col=0 ; $col<$width ; $col++)
    {
        $ncount[$line][] = GetNeighbourCount($line, $col);
    }
}

for ($line=0 ; $line<$height ; $line++)
{
    for($col=0 ; $col<$width ; $col++)
    {
        switch($ncount[$line][$col])
        {
            case 0:
            case 1: if ($lines[$line][$col]=='1')
                        $lines[$line][$col] = '0';
                    break;
            case 3: if ($lines[$line][$col]=='0')
                        $lines[$line][$col] = '1';
                    break;
            case 4: 
            case 5: 
            case 6: 
            case 7: 
            case 8: if ($lines[$line][$col]=='1')
                        $lines[$line][$col] = '0';
                    break;
            default: ;
        }
    }
}

//=========================
$output = "";
foreach ($lines as $line => $cells)
{
    for($i=0 ; $i<$width ; $i++)
        $output .= $cells[$i];
    $output .= "\n";
}
echo($output);
?>
