import React, { useEffect, useRef } from 'react';
import { StyleSheet, TouchableOpacity, View } from 'react-native';
import * as Animatable from 'react-native-animatable';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { LAYOUT, COLORS, TYPOGRAPHY } from '../constants/constants';

const animate1 = { 0: { scale: .5, translateY: 7 }, 0.92: { translateY: -34 }, 1: { scale: 1.2, translateY: -24 } };
const animate2 = { 0: { scale: 1.2, translateY: -24 }, 1: { scale: 1, translateY: 7 } };

const circle1 = { 
  0: { scale: 0 }, 
  0.8: { scale: 1.2 }, 
  1: { scale: 1 } 
};
  
const circle2 = {   
    0: { scale: 1 }, 
    1: { scale: 0 } 
  };

const TabButton = (props) => {
  const { item, onPress, accessibilityState } = props;
  const focused = accessibilityState.selected;
  const viewRef = useRef(null);
  const circleRef = useRef(null);
  const textRef = useRef(null);

  useEffect(() => {
    if (focused) {
      viewRef.current.animate(animate1);
      circleRef.current.animate(circle1);
      textRef.current.transitionTo({ scale: 1 });
    } else {
      viewRef.current.animate(animate2);
      circleRef.current.animate(circle2);
      textRef.current.transitionTo({ scale: 0 });
    }
  }, [focused]);

  return (
    <TouchableOpacity
      onPress={onPress}
      activeOpacity={1}
      style={styles.container}>
      <Animatable.View
        ref={viewRef}
        duration={1000}
        style={styles.container}>
        <View style={styles.btn}>
          <Animatable.View
            ref={circleRef}
            style={styles.circle} />
          <MaterialCommunityIcons 
            name={item.icon} 
            size={LAYOUT.tabBar.iconSize} 
            color={focused ? COLORS.white : COLORS.primary} 
          />
        </View>
        <Animatable.Text
          ref={textRef}
          style={styles.text}>
          {item.label}
        </Animatable.Text>
      </Animatable.View>
    </TouchableOpacity>
  );
};

export function AnimatedTabBar({ tabs, Tabs }) {
  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarStyle: styles.tabBar,
      }}
    >
      {tabs.map((item) => (
        <Tabs.Screen
          key={item.route}
          name={item.route}
          options={{
            tabBarShowLabel: false,
            tabBarButton: (props) => <TabButton {...props} item={item} />
          }}
        />
      ))}
    </Tabs>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    height: LAYOUT.tabBar.height,
  },
  tabBar: {
    height: LAYOUT.tabBar.height,
    position: 'absolute',
    margin: LAYOUT.tabBar.margin,
    borderRadius: LAYOUT.tabBar.borderRadius,
    backgroundColor: COLORS.background,
    shadowColor: COLORS.black,
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  btn: {
    width: LAYOUT.tabBar.buttonSize,
    height: LAYOUT.tabBar.buttonSize,
    borderRadius: LAYOUT.tabBar.borderRadius,
    borderWidth: 1,
    borderColor: COLORS.white,
    backgroundColor: COLORS.background,
    justifyContent: 'center',
    alignItems: 'center',
    overflow: 'hidden', // Чтобы круг не выходил за пределы
  },
  circle: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: COLORS.primary,
    borderRadius: LAYOUT.tabBar.borderRadius,
  },
  text: {
    fontSize: TYPOGRAPHY.sizes.lg,
    textAlign: 'center',
    color: COLORS.text,
    fontWeight: '500'
  }
});

