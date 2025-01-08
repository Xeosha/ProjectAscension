import { Tabs } from "expo-router";
import { AnimatedTabBar } from '../../components/AnimatedTabBar';

const TabArr = [
  { route: 'avatar', label: 'Аватар', icon: 'account' },
  { route: 'map', label: 'Карта', icon: 'map' },
  { route: 'tower', label: 'Лобби', icon: 'castle' },
  { route: 'shop', label: 'Магазин', icon: 'store' },
  { route: 'guild', label: 'Гильдия', icon: 'shield-crown' },
];

export default function Layout() {
  return (
      <AnimatedTabBar tabs={TabArr} Tabs={Tabs} />
  );
}