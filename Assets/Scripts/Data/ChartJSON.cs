﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[Serializable]
public class ChartJSON
{
    public int format_version = 0;
    public int time_base = 480;
    public int start_offset_time = 0;
    public double music_offset = 0;

    public double size = 1.0;
    public double opacity = 1.0;
    public string ring_color = null;
    public List<string> fill_colors = new List<string>(12) { null, null, null, null, null, null, null, null, null, null, null, null };

    public bool ShouldSerializefill_colors()
    {
        return !fill_colors.TrueForAll((string s) => s == null);
    }

    public List<Page> page_list = new List<Page>();
    public List<Tempo> tempo_list = new List<Tempo>();
    public List<EventOrder> event_order_list = new List<EventOrder>();
    public List<Note> note_list = new List<Note>();
}

[Serializable]
public class Page
{
    public int start_tick;
    public int end_tick;
    public int scan_line_direction;
    [NonSerialized, JsonIgnore]
    public double start_time, end_time;
    [JsonIgnore]
    public double PageSize
    {
        get => end_tick - start_tick;
    }
}

[Serializable]
public class Tempo
{
    public int tick;
    public int value;
    [NonSerialized, JsonIgnore]
    public double time;
}

[Serializable]
public class EventOrder
{
    public int tick;
    public List<Event> event_list = new List<Event>();

    [Serializable]
    public class Event
    {
        public int type;
        public string args;
    }
}

[Serializable]
public class Note
{
    public int page_index;
    public int type;
    public int id;
    public int tick;
    public double x;
    public int hold_tick;
    public int next_id;
    public double approach_rate = 1.0;
    public double size = 1.0;
    public string ring_color = null;
    public string fill_color = null;
    public double opacity = -1;

    public bool ShouldSerializeapproch_rate()
    {
        return false;
    }

    public bool ShouldSerializesize()
    {
        return false;
    }

    public bool ShouldSerializeopacity()
    {
        return false;
    }

    [NonSerialized, JsonIgnore]
    public double time, hold_time, approach_time, y;
}