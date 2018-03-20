

using System;
using System.Timers;

public static class Constants
{
    static Constants()
    {
        InitTimerPowerUpAccelerator();
        InitTimerPowerUpBombCount();
        InitTimerPowerUpBombExpander();
        InitTimerPowerUpShull();
    }

    public static int dificultLevel = 30;

    public static float accelerator = 1;
    public static int bombPower = 1;
    public static int bombMax = 1;
    public static int bombExpander = 0;
    public static int skull = 0;

    public static int bombCurrentCount = 0;

    public static bool canCreateBomb
    {
        get
        {
            return bombCurrentCount < bombMax;
        }
    }

    public static bool hasBombExpander
    {
        get
        {
            return bombExpander > 0;
        }
    }

    public const float WorldEndX = WorldBeginX + GridColumns;
    public const float WorldEndY = WorldBeginY - GridLines;
    public const int GridColumns = 20;
    public const int GridLines = 12;
    public const float WorldBeginX = -10f;
    public const float WorldBeginY = 6f;
    public static bool canMove = false;
    public static int tiles = 0;

    private static Timer acceleratorTimer;
    private static Timer bombMaxTimer;
    private static Timer bombExpanderTimer;
    private static Timer skullTimer;

    public static void PowerUpAccelerator()
    {
        if (skull > 0)
        {
            return;
        }

        accelerator = Math.Min(3, accelerator + 0.25f);

        if (!acceleratorTimer.Enabled)
        {
            acceleratorTimer.Enabled = true;
            acceleratorTimer.Start();
        }
    }

    public static void PowerExtraBomb()
    {
        if (skull > 0)
        {
            return;
        }

        bombMax++;

        if (!bombMaxTimer.Enabled)
        {
            bombMaxTimer.Enabled = true;
            bombMaxTimer.Start();
        }
    }

    public static void PowerExplosionExpander()
    {
        if (skull > 0)
        {
            return;
        }

        bombExpander++;

        if (!bombExpanderTimer.Enabled)
        {
            bombExpanderTimer.Enabled = true;
            bombExpanderTimer.Start();
        }
    }

    public static void PowerSkull()
    {
        var rand = new Random();
        var action = rand.Next(0, 3);

        switch (action)
        {
            case 0:
                accelerator = 5;
                break;
            case 1:
                bombMax = 0;
                break;
            case 2:
                accelerator = 0.25f;
                break;
            default:
                break;
        }

        if (!skullTimer.Enabled)
        {
            skullTimer.Enabled = true;
            skullTimer.Start();
        }
    }

    private static void InitTimerPowerUpAccelerator()
    {
        acceleratorTimer = new Timer(60 * 1000)
        {
            Enabled = false,
            AutoReset = false
        };

        acceleratorTimer.Elapsed += (s, e) =>
        {
            accelerator--;

            if (accelerator > 1)
            {
                acceleratorTimer.Start();
                return;
            }

            acceleratorTimer.Enabled = false;
            acceleratorTimer.Stop();
            accelerator = 1;
        };
    }

    private static void InitTimerPowerUpBombCount()
    {
        bombMaxTimer = new Timer(120 * 1000)
        {
            Enabled = false,
            AutoReset = false
        };

        bombMaxTimer.Elapsed += (s, e) =>
        {
            bombMax--;

            if (bombMax > 1)
            {
                bombMaxTimer.Start();
                return;
            }

            bombMaxTimer.Enabled = false;
            bombMaxTimer.Stop();
            bombMax = 1;
        };
    }

    private static void InitTimerPowerUpBombExpander()
    {
        bombExpanderTimer = new Timer(120 * 1000)
        {
            Enabled = false,
            AutoReset = false
        };

        bombExpanderTimer.Elapsed += (s, e) =>
        {
            bombExpander--;

            if (bombExpander > 0)
            {
                bombExpanderTimer.Start();
                return;
            }

            bombExpanderTimer.Enabled = false;
            bombExpanderTimer.Stop();
            bombExpander = 0;
        };
    }

    private static void InitTimerPowerUpShull()
    {
        skullTimer = new Timer(60 * 1000)
        {
            Enabled = false,
            AutoReset = false
        };

        skullTimer.Elapsed += (s, e) =>
        {
            skull = 0;
            accelerator = 1;
            bombPower = 1;
            bombMax = 1;
            bombExpander = 0;

            skullTimer.Enabled = false;
            skullTimer.Stop();
        };
    }
}
