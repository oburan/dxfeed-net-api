﻿using com.dxfeed.api.events;
using System;
using System.Collections.Generic;

namespace com.dxfeed.native {

    /// <summary>
    /// Manages network connections to DXFeed.
    /// </summary>
    public class DXEndpoint {

        /// <summary>
        /// Protected constructor for implementations of DXEndpoint.
        /// </summary>
        protected DXEndpoint() { }

        private static DXEndpoint instance = null;

	    /// <summary>
        /// Returns a default application-wide singleton instance of DXEndpoint with a default role.
	    /// Most applications use only a single data-source and should rely on this method to get one.
        /// </summary>
        /// <returns></returns>
        public static DXEndpoint GetInstance() {
            if (instance == null)
                instance = new DXEndpoint();
            return instance;
        }

        /// <summary>
        /// Returns a set of all event types supported by this endpoint. The resulting set cannot be modified.
        /// </summary>
        /// <returns></returns>
        public HashSet<Type> GetEventTypes() {
            return new HashSet<Type>(new Type[] {
                typeof(IDxCandle),
                typeof(IDxMarketMaker),
                typeof(IDxOrder),
                typeof(IDxProfile),
                typeof(IDxQuote),
                typeof(IDxSummary),
                typeof(IDxTimeAndSale),
                typeof(IDxTrade)
            });
        }
    }
}
