﻿using System;
using System.Timers;

public class PlayerPowersUps
{
    public PlayerPowersUps()
    {
        InitTimerPowerUpAccelerator();
        InitTimerPowerUpBombCount();
        InitTimerPowerUpBombExpander();
        InitTimerPowerUpShull();
    }
    
    private float constatSpeed = 5;

    public float accelerator = 1;
    public int bombPower = 1;
    public int bombMax = 1;
    public int bombExpander = 0;
    public int skull = 0;
    public int bombCurrentCount = 0;
    public int playerId = 0;

    public bool canCreateBomb
    {
        get
        {
            return bombCurrentCount < bombMax;
        }
    }

    public bool hasBombExpander
    {
        get
        {
            return bombExpander > 0;
        }
    }

    public float moveSpeed
    {
        get
        {
            return constatSpeed * accelerator;
        }
    }

    public string VerticalAxis
    {
        get
        {
            return string.Format("VerticalPlayer{0}", playerId);
        }
    }

    public string HorizontalAxis
    {
        get
        {
            return string.Format("HorizontalPlayer{0}", playerId);
        }
    }

    public string FireAxis
    {
        get
        {
            return string.Format("FirePlayer{0}", playerId);
        }
    }

    private static Timer acceleratorTimer;
    private static Timer bombMaxTimer;
    private static Timer bombExpanderTimer;
    private static Timer skullTimer;

    public void PowerUpAccelerator()
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

    public void PowerExtraBomb()
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

    public void PowerExplosionExpander()
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

    public void PowerSkull()
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

    private void InitTimerPowerUpAccelerator()
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

    private void InitTimerPowerUpBombCount()
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

    private void InitTimerPowerUpBombExpander()
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

    private void InitTimerPowerUpShull()
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