﻿using System.Collections.Generic;

namespace OpenNLP.Tools.Util
{
    /// <summary>
    /// A Set that also represents an ordering of its elements, and responds
    /// quickly to {@code add()}, {@code changePriority()},
    /// {@code removeFirst()}, and {@code getFirst()} method calls. <p/>
    /// There are several important differences between this interface and
    /// the JDK {@link java.util.PriorityQueue}: <p/>
    /// <ol>
    /// <li> This interface uses explicitly-assigned <code>double</code> values
    /// as priorities for queue elements, while
    /// <code>java.util.PriorityQueue</code> uses either the elements'
    /// <i>natural order</i> (see {@link java.lang.Comparable}) or a {@link
    /// java.util.Comparator}.</li>
    /// 
    /// <li> In this interface, larger <code>double</code>s represent higher
    /// priorities; in <code>java.util.PriorityQueue</code>, <i>lesser</i>
    /// elements (with respect to the specified ordering) have higher
    /// priorities.</li>
    /// 
    /// <li> This interface enables you to <i>change</i> the priority of an
    /// element <i>after</i> it has entered the queue.  With
    /// <code>java.util.PriorityQueue</code>, that's not possible.</li>
    /// 
    /// <li> However, there is a price to pay for this flexibility.  The primary
    /// implementation of this interface, {@link
    /// edu.stanford.nlp.util.BinaryHeapPriorityQueue}, is roughly 2x slower
    /// than <code>java.util.PriorityQueue</code> in informal benchmark
    /// testing.</li>
    /// 
    /// <li> So, there's another implementation of this interface,
    /// FixedPrioritiesPriorityQueue, which trades flexibility for speed: while
    /// it is up to 2x faster than {@link BinaryHeapPriorityQueue} and nearly as
    /// fast as {@link java.util.PriorityQueue}, it does not support removing or
    /// changing the priority of an element.</li>
    /// </ol>
    /// 
    /// On the other hand, this interface and {@link java.util.PriorityQueue}
    /// also have some characteristics in common: <p/>
    /// <ol>
    /// <li> Both make no guarantee about the order in which elements with equal
    /// priority are returned from the queue.  This does <i>not</i> mean that
    /// equal elements are returned in <i>random</i> order.  (In fact they are
    /// returned in an order which depends on the order of insertion em-dash but
    /// the implementations reserve the right to return them in any order
    /// whatsoever.)</li>
    /// </ol>
    /// 
    /// @author Teg Grenager (grenager@cs.stanford.edu)
    /// @author Bill MacCartney
    /// 
    /// Code retrieved on the Stanford parser and ported to C# (see http://nlp.stanford.edu/software/lex-parser.shtml)
    /// </summary>
    public interface IPriorityQueue<E> /*:ISet<E>*/
    {

        /// <summary>
        /// Finds the object with the highest priority, removes it, and returns it.
        /// </summary>
        /// <returns>the object with highest priority</returns>
        E RemoveFirst();

        /// <summary>
        /// Finds the object with the highest priority and returns it, without modifying the queue.
        /// </summary>
        /// <returns>the object with minimum key</returns>
        E GetFirst();

        /// <summary>
        /// Gets the priority of the highest-priority element of the queue (without modifying the queue).
        /// </summary>
        /// <returns>The priority of the highest-priority element of the queue.</returns>
        double GetPriority();

        /// <summary>
        /// Get the priority of a key.
        /// </summary>
        /// <param name="key">The object to assess</param>
        /// <returns>A key's priority. If the key is not in the queue, Double.NEGATIVE_INFINITY is returned.</returns>
        double GetPriority(E key);

        /// <summary>
        /// Convenience method for if you want to pretend relaxPriority doesn't exist,
        /// or if you really want to use the return conditions of add().
        /// 
        /// Warning: The semantics of this method currently varies between implementations.
        /// In some implementations, nothing will be changed if the key is already in the
        /// priority queue. In others, the element will be added a second time with the
        /// new priority. We maybe should at least change things so that the priority
        /// will be change to the priority given if the element is in the queue with
        /// a lower priority, but that wasn't the historical behavior, and it seemed like
        /// we'd need to do a lot of archeology before changing the behavior.
        /// </summary>
        /// <returns> <tt>true</tt> if this set did not already contain the specified element.</returns>
        bool Add(E key, double priority);

        /// <summary>
        /// Changes a priority, either up or down, adding the key it if it wasn't there already.
        /// </summary>
        /// <returns>whether the priority actually changed.</returns>
        bool ChangePriority(E key, double priority);

        /// <summary>
        /// Increases the priority of the E key to the new priority if the old priority
        ///  was lower than the new priority. Otherwise, does nothing.
        /// </summary>
        bool RelaxPriority(E key, double priority);

        List<E> ToSortedList();

        /// <summary>
        /// Returns a representation of the queue in decreasing priority order,
        /// displaying at most maxKeysToPrint elements.
        /// </summary>
        /// <param name="maxKeysToPrint">The maximum number of keys to print. 
        /// Less are printed if there are less than this number of items in the PriorityQueue. 
        /// If this number is non-positive, then all elements in the PriorityQueue are printed.</param>
        /// <returns>A string representation of the high priority items in the queue.</returns>
        string ToString(int maxKeysToPrint);
    }
}