﻿using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ScrollPattern : PatternBaseWithInformation<UIA.IUIAutomationScrollPattern, ScrollPatternInformation>, IScrollPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ScrollPatternId, "Scroll", AutomationObjectIds.IsScrollPatternAvailableProperty);
        public static readonly PropertyId HorizontallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontallyScrollablePropertyId, "HorizontallyScrollable");
        public static readonly PropertyId HorizontalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalScrollPercentPropertyId, "HorizontalScrollPercent");
        public static readonly PropertyId HorizontalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalViewSizePropertyId, "HorizontalViewSize");
        public static readonly PropertyId VerticallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticallyScrollablePropertyId, "VerticallyScrollable");
        public static readonly PropertyId VerticalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalScrollPercentPropertyId, "VerticalScrollPercent");
        public static readonly PropertyId VerticalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalViewSizePropertyId, "VerticalViewSize");

        public ScrollPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationScrollPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IScrollPatternInformation IPatternWithInformation<IScrollPatternInformation>.Cached => Cached;

        IScrollPatternInformation IPatternWithInformation<IScrollPatternInformation>.Current => Current;

        public IScrollPatternProperties Properties => Automation.PropertyLibrary.Scroll;

        protected override ScrollPatternInformation CreateInformation()
        {
            return new ScrollPatternInformation(BasicAutomationElement);
        }

        public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            ComCallWrapper.Call(() => NativePattern.Scroll((UIA.ScrollAmount)horizontalAmount, (UIA.ScrollAmount)verticalAmount));
        }

        public void SetScrollPercent(double horizontalPercent, double verticalPercent)
        {
            ComCallWrapper.Call(() => NativePattern.SetScrollPercent(horizontalPercent, verticalPercent));
        }
    }

    public class ScrollPatternInformation : InformationBase, IScrollPatternInformation
    {
        public ScrollPatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public bool HorizontallyScrollable => Get<bool>(ScrollPattern.HorizontallyScrollableProperty);

        public double HorizontalScrollPercent => Get<double>(ScrollPattern.HorizontalScrollPercentProperty);

        public double HorizontalViewSize => Get<double>(ScrollPattern.HorizontalViewSizeProperty);

        public bool VerticallyScrollable => Get<bool>(ScrollPattern.VerticallyScrollableProperty);

        public double VerticalScrollPercent => Get<double>(ScrollPattern.VerticalScrollPercentProperty);

        public double VerticalViewSize => Get<double>(ScrollPattern.VerticalViewSizeProperty);
    }

    public class ScrollPatternProperties : IScrollPatternProperties
    {
        public PropertyId HorizontallyScrollableProperty => ScrollPattern.HorizontallyScrollableProperty;

        public PropertyId HorizontalScrollPercentProperty => ScrollPattern.HorizontalScrollPercentProperty;

        public PropertyId HorizontalViewSizeProperty => ScrollPattern.HorizontalViewSizeProperty;

        public PropertyId VerticallyScrollableProperty => ScrollPattern.VerticallyScrollableProperty;

        public PropertyId VerticalScrollPercentProperty => ScrollPattern.VerticalScrollPercentProperty;

        public PropertyId VerticalViewSizeProperty => ScrollPattern.VerticalViewSizeProperty;
    }
}
