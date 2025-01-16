import React, { useEffect } from "react";
import { StyleSheet, TouchableOpacity, View, Text } from "react-native";
import Animated, {
  useSharedValue,
  useAnimatedStyle,
  withTiming,
  withSpring,
} from "react-native-reanimated";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { COLORS, FONTS } from "../constants/constants";
import useResponsiveScreen from "../hooks/useResponsiveScreen";

const TabButton = ({ item, onPress, accessibilityState }) => {
  const focused = accessibilityState.selected;
  const { hp } = useResponsiveScreen();

  // Shared values for animations
  const scale = useSharedValue(1);
  const translateY = useSharedValue(0);
  const circleScale = useSharedValue(0);
  const textScale = useSharedValue(0);

  // Animated styles
  const animatedStyle = useAnimatedStyle(() => ({
    transform: [
      { scale: scale.value },
      { translateY: translateY.value },
    ],
  }));

  const circleStyle = useAnimatedStyle(() => ({
    transform: [{ scale: circleScale.value }],
  }));

  const textStyle = useAnimatedStyle(() => ({
    transform: [{ scale: textScale.value }],
  }));

  // Update animations on focus change
  useEffect(() => {
    if (focused) {
      scale.value = withSpring(1.2);
      translateY.value = withSpring(-hp(7) / 3);
      circleScale.value = withTiming(1, { duration: 300 });
      textScale.value = withTiming(1, { duration: 300 });
    } else {
      scale.value = withSpring(1);
      translateY.value = withSpring(7);
      circleScale.value = withTiming(0, { duration: 300 });
      textScale.value = withTiming(0, { duration: 300 });
    }
  }, [focused]);

  return (
    <TouchableOpacity
      onPress={onPress}
      activeOpacity={1}
      style={styles.container}
    >
      <Animated.View style={[styles.container, animatedStyle]}>
        <View
          style={[
            styles.btn,
            { width: hp(5), height: hp(5), borderRadius: hp(5) },
          ]}
        >
          <Animated.View
            style={[
              styles.circle,
              { borderRadius: hp(5) },
              circleStyle,
            ]}
          />
          <MaterialCommunityIcons
            name={item.icon}
            size={hp(4)}
            color={focused ? COLORS.white : COLORS.primary}
          />
        </View>
        <Animated.Text
          style={[styles.text, { fontSize: hp(1) }, textStyle]}
        >
          {item.label}
        </Animated.Text>
      </Animated.View>
    </TouchableOpacity>
  );
};

export function AnimatedTabBar({ tabs, Tabs }) {
  const { wp, hp } = useResponsiveScreen();

  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarStyle: [
          styles.tabBar,
          {
            height: hp(8),
            bottom: hp(1),
            marginHorizontal: wp(36) > 300 ? wp(36) : 15,
          },
        ],
      }}
    >
      {tabs.map((item) => (
        <Tabs.Screen
          key={item.route}
          name={item.route}
          options={{
            tabBarShowLabel: false,
            tabBarButton: (props) => <TabButton {...props} item={item} />,
          }}
        />
      ))}
    </Tabs>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
  tabBar: {
    position: "absolute",
    borderRadius: 32,
    backgroundColor: COLORS.surface,
    shadowColor: COLORS.black,
    shadowOffset: {
      width: 2,
      height: 4,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  btn: {
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: COLORS.surface,
  },
  circle: {
    ...StyleSheet.absoluteFillObject,
    alignItems: "center",
    justifyContent: "center",
    backgroundColor: COLORS.primary,
  },
  text: {
    paddingTop: 5,
    textAlign: "center",
    color: COLORS.white,
    fontWeight: "500",
    fontFamily: FONTS.regular,
  },
});
