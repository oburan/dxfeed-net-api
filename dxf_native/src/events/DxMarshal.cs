﻿/// Copyright (C) 2010-2016 Devexperts LLC
///
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// http://mozilla.org/MPL/2.0/.

using System;
using System.Runtime.InteropServices;
using com.dxfeed.api.data;
using com.dxfeed.native.api;

namespace com.dxfeed.native.events
{
    public unsafe class DxMarshal
    {
        private static readonly int QUOTE_SIZE;
        private static readonly int ORDER_SIZE;
        private static readonly int TRADE_SIZE;
        private static readonly int SUMMARY_SIZE;
        private static readonly int PROFILE_SIZE;
        private static readonly int MM_SIZE;
        private static readonly int TS_SIZE;
        private static readonly int CANDLE_SIZE;
        private static readonly int TRADE_ETH_SIZE;

        static DxMarshal()
        {
            QUOTE_SIZE = sizeof(DxQuote);
            ORDER_SIZE = sizeof(DxOrder);
            TRADE_SIZE = sizeof(DxTrade);
            SUMMARY_SIZE = sizeof(DxSummary);
            PROFILE_SIZE = sizeof(DxProfile);
            MM_SIZE = sizeof(DxMarketMaker);
            TS_SIZE = sizeof(DxTimeAndSale);
            CANDLE_SIZE = sizeof(DxCandle);
            TRADE_ETH_SIZE = sizeof(DxTradeEth);
        }

        public static string ReadString(IntPtr ptr)
        {
            return Marshal.PtrToStringUni(ptr);
        }

        public static NativeQuote ReadQuote(IntPtr head, int offset, string symbol)
        {
            return new NativeQuote((DxQuote*)IntPtr.Add(head, offset * QUOTE_SIZE), symbol);
        }

        public static NativeOrder ReadOrder(IntPtr head, int offset, string symbol)
        {
            return new NativeOrder((DxOrder*)IntPtr.Add(head, offset * ORDER_SIZE), symbol);
        }

        public static NativeTrade ReadTrade(IntPtr head, int offset, string symbol)
        {
            return new NativeTrade((DxTrade*)IntPtr.Add(head, offset * TRADE_SIZE), symbol);
        }

        public static NativeSummary ReadSummary(IntPtr head, int offset, string symbol)
        {
            return new NativeSummary((DxSummary*)IntPtr.Add(head, offset * SUMMARY_SIZE), symbol);
        }

        public static NativeProfile ReadProfile(IntPtr head, int offset, string symbol)
        {
            return new NativeProfile((DxProfile*)IntPtr.Add(head, offset * PROFILE_SIZE), symbol);
        }

        public static NativeMarketMaker ReadMarketMaker(IntPtr head, int offset, string symbol)
        {
            return new NativeMarketMaker((DxMarketMaker*)IntPtr.Add(head, offset * MM_SIZE), symbol);
        }

        public static NativeTimeAndSale ReadTimeAndSale(IntPtr head, int offset, string symbol)
        {
            return new NativeTimeAndSale((DxTimeAndSale*)IntPtr.Add(head, offset * TS_SIZE), symbol);
        }

        public static NativeCandle ReadCandle(IntPtr head, int offset, string symbol)
        {
            return new NativeCandle((DxCandle*)IntPtr.Add(head, offset * CANDLE_SIZE), symbol);
        }

        public static NativeTradeETH ReadTradeEth(IntPtr head, int offset, string symbol)
        {
            return new NativeTradeETH((DxTradeEth*)IntPtr.Add(head, offset * TRADE_ETH_SIZE), symbol);
        }

        public static DxString ReadDxString(IntPtr ptr)
        {
            return new DxString((char*)ptr.ToPointer());
        }

    }
}