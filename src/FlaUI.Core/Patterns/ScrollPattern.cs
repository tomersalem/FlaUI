﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public class ScrollPatternConstants
    {
        public const double NoScroll = -1.0;
    }

    public interface IScrollPattern : IPattern
    {
        IScrollPatternProperties Properties { get; }

        AutomationProperty<bool> HorizontallyScrollable { get; }
        AutomationProperty<double> HorizontalScrollPercent { get; }
        AutomationProperty<double> HorizontalViewSize { get; }
        AutomationProperty<bool> VerticallyScrollable { get; }
        AutomationProperty<double> VerticalScrollPercent { get; }
        AutomationProperty<double> VerticalViewSize { get; }

        void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }

    public interface IScrollPatternProperties
    {
        PropertyId HorizontallyScrollableProperty { get; }
        PropertyId HorizontalScrollPercentProperty { get; }
        PropertyId HorizontalViewSizeProperty { get; }
        PropertyId VerticallyScrollableProperty { get; }
        PropertyId VerticalScrollPercentProperty { get; }
        PropertyId VerticalViewSizeProperty { get; }
    }

    public abstract class ScrollPatternBase<TNativePattern> : PatternBase<TNativePattern>, IScrollPattern
    {
        protected ScrollPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            HorizontallyScrollable = new AutomationProperty<bool>(() => Properties.HorizontallyScrollableProperty, BasicAutomationElement);
            HorizontalScrollPercent = new AutomationProperty<double>(() => Properties.HorizontalScrollPercentProperty, BasicAutomationElement);
            HorizontalViewSize = new AutomationProperty<double>(() => Properties.HorizontalViewSizeProperty, BasicAutomationElement);
            VerticallyScrollable = new AutomationProperty<bool>(() => Properties.VerticallyScrollableProperty, BasicAutomationElement);
            VerticalScrollPercent = new AutomationProperty<double>(() => Properties.VerticalScrollPercentProperty, BasicAutomationElement);
            VerticalViewSize = new AutomationProperty<double>(() => Properties.VerticalViewSizeProperty, BasicAutomationElement);
        }

        public IScrollPatternProperties Properties => Automation.PropertyLibrary.Scroll;

        public AutomationProperty<bool> HorizontallyScrollable { get; }
        public AutomationProperty<double> HorizontalScrollPercent { get; }
        public AutomationProperty<double> HorizontalViewSize { get; }
        public AutomationProperty<bool> VerticallyScrollable { get; }
        public AutomationProperty<double> VerticalScrollPercent { get; }
        public AutomationProperty<double> VerticalViewSize { get; }

        public abstract void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        public abstract void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }
}
